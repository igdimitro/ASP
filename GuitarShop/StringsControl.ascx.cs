using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace GuitarShop
{
    public partial class StringsControl : System.Web.UI.UserControl
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

        public Int32 stringsID
        {
            get
            {
                object o = ViewState["stringsID"];
                return (o == null) ? Int32.Parse(this.InputID.Text.Trim()) : Int32.Parse(o.ToString().Trim());
            }
            set
            {
                this.InputID.Text = (value).ToString().Trim();
                ViewState["stringsID"] = this.InputID.Text.Trim();
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

        public Double gauge
        {
            get
            {
                object o = ViewState["gauge"];
                return (o == null) ? Double.Parse(this.InputGauge.Text.Trim()) : Double.Parse(o.ToString().Trim());
            }
            set
            {
                this.InputGauge.Text = (value).ToString().Trim();
                ViewState["gauge"] = this.InputGauge.Text.Trim();
            }
        }

        protected void ValidateID(object source, ServerValidateEventArgs args)
        {
            Int32 strID = Int32.Parse(args.Value);
            if (Regex.IsMatch(strID.ToString(), @"^\d+$"))
            {
                GuitarShopEntities6 context = new GuitarShopEntities6();
                var strIDs =
                    from s in context.Strings
                    select s.stringsID;
                if (!strIDs.Any(g => g == strID))
                    args.IsValid = true;
                else
                {
                    SID.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                SID.ErrorMessage = "* Невалидно ID";
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
                SP.ErrorMessage = "Невалидна цена!";
                args.IsValid = false;
            }
        }

        protected void ValidateGauge(object source, ServerValidateEventArgs args)
        {
            string gauge = args.Value;
            Double pr;
            if (Double.TryParse(gauge, out pr))
            {
                args.IsValid = true;
            }
            else
            {
                CVG.ErrorMessage = "Невалиден размер!";
                args.IsValid = false;
            }
        }

        public void fillProperties(Strings str, int guitarShopID)
        {
            str.stringsID = Int32.Parse(InputID.Text);
            str.GuitarShopID = guitarShopID;
            str.strings_type = InputType.SelectedValue;
            str.manufacturer = InputManufacturer.Text;
            str.gauge = Double.Parse(InputGauge.Text);
            str.description = InputDescription.Text;
            str.price_value = Double.Parse(InputPrice.Text);
            str.price_currency = InputCurrency.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}