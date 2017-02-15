using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace GuitarShop
{
    public partial class AcousticGuitarControl : System.Web.UI.UserControl
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

        public Int32 guitarID
        {
            get
            {
                object o = ViewState["guitarID"];
                return (o == null) ? Int32.Parse(this.InputID.Text.Trim()) : Int32.Parse(o.ToString().Trim());
            }
            set
            {
                this.InputID.Text = (value).ToString().Trim();
                ViewState["guitarID"] = this.InputID.Text.Trim();
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

        public Byte number_strings
        {
            get
            {
                object o = ViewState["number_strings"];
                return (o == null) ? Byte.Parse(this.InputNumStrings.Text.Trim()) : Byte.Parse(o.ToString().Trim());
            }
            set
            {
                this.InputNumStrings.Text = (value).ToString().Trim();
                ViewState["number_strings"] = this.InputNumStrings.Text.Trim();
            }
        }

        public string body
        {
            get
            {
                object o = ViewState["body"];
                return (o == null) ? this.InputBody.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputBody.Text = value.Trim();
                ViewState["body"] = this.InputBody.Text.Trim();
            }
        }

        protected void ValidateID(object source, ServerValidateEventArgs args)
        {
            Int32 guitarID = Int32.Parse(args.Value);
            if (Regex.IsMatch(guitarID.ToString(), @"^\d+$"))
            {
                GuitarShopEntities6 context = new GuitarShopEntities6();
                var guitarIDs =
                    from g in context.AcousticGuitars
                    select g.guitarID;
                if (!guitarIDs.Any(g => g == guitarID))
                    args.IsValid = true;
                else
                {
                    IDAG.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                IDAG.ErrorMessage = "* Невалидно ID";
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
                PAG.ErrorMessage = "Невалидна цена!";
                args.IsValid = false;
            }
        }

        public void fillProperties(AcousticGuitars ag, int guitarShopID)
        {
            ag.guitarID = Int32.Parse(InputID.Text);
            ag.GuitarShopID = guitarShopID;
            ag.electro_acoustic = InputElectroAcoustic.SelectedValue;
            ag.manufacturer = InputManufacturer.Text;
            ag.model = InputModel.Text;
            ag.number_strings = Byte.Parse(InputNumStrings.Text);
            ag.description = InputDescription.Text;
            ag.price_value = Double.Parse(InputPrice.Text);
            ag.price_currency = InputCurrency.Text;
            ag.body = InputBody.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}