using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace GuitarShop
{
    public partial class AmplifierControl : System.Web.UI.UserControl
    {

        public Int32 GuitarShopID
        {
            get
            {
                object o = ViewState["GuitarShopID"];
                return Int32.Parse(o.ToString().Trim());
            }
            set
            {
                ViewState["GuitarShopID"] = (value).ToString().Trim();
            }
        }

        public Int32 ampID
        {
            get
            {
                object o = ViewState["ampID"];
                return (o == null) ? Int32.Parse(this.InputID.Text.Trim()) : Int32.Parse(o.ToString().Trim());
            }
            set
            {
                this.InputID.Text = (value).ToString().Trim();
                ViewState["ampID"] = this.InputID.Text.Trim();
            }
        }

        public string manufacturer
        {
            get
            {
                object o = ViewState["manufacturer"];
                return (o == null) ? this.InputManufacturer.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputManufacturer.Text = value.Trim();
                ViewState["manufacturer"] = this.InputManufacturer.Text.Trim();
            }
        }

        public string model
        {
            get
            {
                object o = ViewState["model"];
                return (o == null) ? this.InputModel.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputModel.Text = value.Trim();
                ViewState["model"] = this.InputModel.Text.Trim();
            }
        }

        public string description
        {
            get
            {
                object o = ViewState["description"];
                return (o == null) ? this.InputDescription.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputDescription.Text = value.Trim();
                ViewState["description"] = this.InputDescription.Text.Trim();
            }
        }

        public Double price_value
        {
            get
            {
                object o = ViewState["price_value"];
                return (o == null) ? Double.Parse(this.InputPrice.Text.Trim()) : Double.Parse(o.ToString().Trim());
            }
            set
            {
                this.InputPrice.Text = (value).ToString().Trim();
                ViewState["price_value"] = this.InputPrice.Text.Trim();
            }
        }

        public string price_currency
        {
            get
            {
                object o = ViewState["price_currency"];
                return (o == null) ? this.InputCurrency.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputCurrency.Text = value.Trim();
                ViewState["price_currency"] = this.InputCurrency.Text.Trim();
            }
        }

        public Double power
        {
            get
            {
                object o = ViewState["power"];
                return (o == null) ? Double.Parse(this.InputPower.Text.Trim()) : Double.Parse(o.ToString().Trim());
            }
            set
            {
                this.InputPower.Text = (value).ToString().Trim();
                ViewState["power"] = this.InputPower.Text.Trim();
            }
        }

        public string power_unit
        {
            get
            {
                object o = ViewState["power_unit"];
                return (o == null) ? this.InputPowerUnit.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputPowerUnit.Text = value.Trim();
                ViewState["power_unit"] = this.InputPowerUnit.Text.Trim();
            }
        }

        protected void ValidateID(object source, ServerValidateEventArgs args)
        {
            Int32 ampID = Int32.Parse(args.Value);
            if (Regex.IsMatch(ampID.ToString(), @"^\d+$"))
            {
                GuitarShopEntities6 context = new GuitarShopEntities6();
                var ampIDs =
                    from a in context.Amplifiers
                    select a.ampID;
                if (!ampIDs.Any(g => g == ampID))
                    args.IsValid = true;
                else
                {
                    IDA.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                IDA.ErrorMessage = "* Невалидно ID";
                args.IsValid = false;
            }
        }

        protected void ValidatePrice(object source, ServerValidateEventArgs args)
        {
            string price = args.Value;
            Double pr;
            if (Double.TryParse(price, out pr))
            {
                args.IsValid = true;
            }
            else
            {
                PA.ErrorMessage = "Невалидна цена!";
                args.IsValid = false;
            }
        }

        protected void ValidatePower(object source, ServerValidateEventArgs args)
        {
            string power = args.Value;
            Double pr;
            if (Double.TryParse(power, out pr))
            {
                args.IsValid = true;
            }
            else
            {
                CVP.ErrorMessage = "Невалидна мощност!";
                args.IsValid = false;
            }
        }

        public void fillProperties(Amplifiers amp, int guitarShopID)
        {
            amp.ampID = Int32.Parse(InputID.Text);
            amp.GuitarShopID = guitarShopID;
            amp.manufacturer = InputManufacturer.Text;
            amp.amplifier_type = InputType.SelectedValue;
            amp.model = InputModel.Text;
            amp.description = InputDescription.Text;
            amp.price_value = Double.Parse(InputPrice.Text);
            amp.price_currency = InputCurrency.Text;
            amp.power = Double.Parse(InputPower.Text);
            amp.power_unit = InputPowerUnit.SelectedValue;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}