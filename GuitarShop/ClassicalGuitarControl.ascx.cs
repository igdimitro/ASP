using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace GuitarShop
{
    public partial class ClassicalGuitarControl : System.Web.UI.UserControl
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

        protected void ValidateID(object source, ServerValidateEventArgs args)
        {
            Int32 guitarID = Int32.Parse(args.Value);
            if (Regex.IsMatch(guitarID.ToString(), @"^\d+$"))
            {
                GuitarShopEntities6 context = new GuitarShopEntities6();
                var guitarIDs =
                    from g in context.ClassicalGuitars
                    select g.guitarID;
                if (!guitarIDs.Any(g => g == guitarID))
                    args.IsValid = true;
                else
                {
                    IDCG.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                IDCG.ErrorMessage = "* Невалидно ID";
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
                PCG.ErrorMessage = "Невалидна цена!";
                args.IsValid = false;
            }
        }

        public void fillProperties(ClassicalGuitars cg, int guitarShopID)
        {
            cg.guitarID = Int32.Parse(InputID.Text);
            cg.GuitarShopID = guitarShopID;
            cg.electro_acoustic = InputElectroAcoustic.SelectedValue;
            cg.manufacturer = InputManufacturer.Text;
            cg.model = InputModel.Text;
            cg.price_value = Double.Parse(InputPrice.Text);
            cg.price_currency = InputCurrency.Text;
            cg.description = InputDescription.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}