using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace GuitarShop
{
    public partial class ElectricGuitarControl : System.Web.UI.UserControl
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

        public Byte number_frets
        {
            get
            {
                object o = ViewState["number_frets"];
                return (o == null) ? Byte.Parse(this.InputNumFrets.Text.Trim()) : Byte.Parse(o.ToString().Trim());
            }
            set
            {
                this.InputNumFrets.Text = (value).ToString().Trim();
                ViewState["number_frets"] = this.InputNumFrets.Text.Trim();
            }
        }

        public string tremolo
        {
            get
            {
                object o = ViewState["tremolo"];
                return (o == null) ? this.InputTremolo.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputTremolo.Text = value.Trim();
                ViewState["tremolo"] = this.InputTremolo.Text.Trim();
            }
        }

        public string pickguard
        {
            get
            {
                object o = ViewState["pickguard"];
                return (o == null) ? this.InputPickguard.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputPickguard.Text = value.Trim();
                ViewState["pickguard"] = this.InputPickguard.Text.Trim();
            }
        }

        public string neckpickup
        {
            get
            {
                object o = ViewState["neckpickup"];
                return (o == null) ? this.InputNeckPickup.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputNeckPickup.Text = value.Trim();
                ViewState["neckpickup"] = this.InputNeckPickup.Text.Trim();
            }
        }

        public string middlepickup
        {
            get
            {
                object o = ViewState["middlepickup"];
                return (o == null) ? this.InputMiddlePickup.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputMiddlePickup.Text = value.Trim();
                ViewState["middlepickup"] = this.InputMiddlePickup.Text.Trim();
            }
        }

        public string bridgepickup
        {
            get
            {
                object o = ViewState["bridgepickup"];
                return (o == null) ? this.InputBridgePickup.Text.Trim() : o.ToString().Trim();
            }
            set
            {
                this.InputBridgePickup.Text = value.Trim();
                ViewState["bridgepickup"] = this.InputBridgePickup.Text.Trim();
            }
        }


       public void fillProperties(ElectricGuitars eg, int guitarShopID)
        {
            eg.guitarID = Int32.Parse(InputID.Text);
            eg.GuitarShopID = guitarShopID;
            eg.manufacturer = InputManufacturer.Text;
            eg.model = InputModel.Text;
            eg.number_strings = Byte.Parse(InputNumStrings.Text);
            eg.number_frets = Byte.Parse(InputNumFrets.Text);
            eg.description = InputDescription.Text;
            eg.price_value = Double.Parse(InputPrice.Text);
            eg.price_currency = InputCurrency.Text;
            eg.body = InputBody.Text;
            Pickups neckpickup = new Pickups();
            neckpickup.guitarID = Int32.Parse(InputID.Text);
            neckpickup.pickup_type = InputNeckPickup.SelectedValue;
            neckpickup.pickup_position = "neck";
            eg.Pickups.Add(neckpickup);
            Pickups middlepickup = new Pickups();
            if (InputMiddlePickup.SelectedValue != "none") 
            {
                middlepickup.pickup_type = InputMiddlePickup.SelectedValue;
                middlepickup.pickup_position = "middle";
                eg.Pickups.Add(middlepickup);
            }
            Pickups bridgepickup = new Pickups();
            bridgepickup.pickup_type = InputBridgePickup.SelectedValue;
            bridgepickup.pickup_position = "bridge";            
            eg.Pickups.Add(bridgepickup);
            eg.tremolo = InputTremolo.SelectedValue;
            eg.pickguard = InputPickguard.SelectedValue;
        }

       protected void ValidateID(object source, ServerValidateEventArgs args)
       {
           Int32 guitarID = Int32.Parse(args.Value);
           if (Regex.IsMatch(guitarID.ToString(), @"^\d+$"))
           {
               GuitarShopEntities6 context = new GuitarShopEntities6();
               var guitarIDs =
                   from g in context.ElectricGuitars
                   select g.guitarID;
               if (!guitarIDs.Any(g => g == guitarID))
                   args.IsValid = true;
               else
               {
                   CustomValidator10.ErrorMessage = "* Съществуващо ID";
                   args.IsValid = false;
               }
           }
           else
           {
               CustomValidator10.ErrorMessage = "* Невалидно ID";
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
                CustomValidator5.ErrorMessage = "Невалидна цена!";
                args.IsValid = false;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}