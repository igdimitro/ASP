using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using GuitarShop.App_Code;
using System.IO;

namespace GuitarShop
{
    public partial class DataInput : System.Web.UI.Page
    {

        static int elelectricGuitarsCount, acousticGuitarsCount, classicalGuitarsCount, amplifiersCount, stringsCount = 0;
        private List<ElectricGuitarControl> dynamicElectricGuitars;
        private List<AcousticGuitarControl> dynamicAcousticGuitars;
        private List<ClassicalGuitarControl> dynamicClassicalGuitars;
        private List<AmplifierControl> dynamicAmplifiers;
        private List<StringsControl> dynamicStrings;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (this.Page.Request.Form.AllKeys.Contains("ctl00$body$btnAddElectricGuitar"))
            {
                elelectricGuitarsCount++;
            }
            if (this.Page.Request.Form.AllKeys.Contains("ctl00$body$btnAddAcousticGuitar"))
            {
                acousticGuitarsCount++;
            }
            if (this.Page.Request.Form.AllKeys.Contains("ctl00$body$btnAddClassicalGuitar"))
            {
                classicalGuitarsCount++;
            }
            if (this.Page.Request.Form.AllKeys.Contains("ctl00$body$btnAddAmplifier"))
            {
                amplifiersCount++;
            }
            if (this.Page.Request.Form.AllKeys.Contains("ctl00$body$btnAddStrings"))
            {
                stringsCount++;
            }
        }

        private void initElectricGuitars()
        {
            dynamicElectricGuitars = new List<ElectricGuitarControl>();
            for (int i = 0; i < elelectricGuitarsCount; i++)
            {
                ElectricGuitarControl egc = LoadControl("~/ElectricGuitarControl.ascx") as ElectricGuitarControl;
                egc.ID = "eg" + (i + 1).ToString();
                dynamicElectricGuitars.Add(egc);
                ElectricGuitarsPlaceHolder.Controls.Add(egc);

                if (elelectricGuitarsCount > 1)
                {
                    Button button = new Button();
                    button.ID = "rm" + (i + 1).ToString();
                    button.Text = "Изтрий";
                    button.Click += new EventHandler(RemoveEG);
                    button.CausesValidation = false;
                    ElectricGuitarsPlaceHolder.Controls.Add(button);
                }
            }
        }

        private void initAcousticGuitars()
        {
            dynamicAcousticGuitars = new List<AcousticGuitarControl>();
            for (int i = 0; i < acousticGuitarsCount; i++)
            {
                AcousticGuitarControl agc = LoadControl("~/AcousticGuitarControl.ascx") as AcousticGuitarControl;
                agc.ID = "ag" + (i + 1).ToString();
                dynamicAcousticGuitars.Add(agc);
                AcousticGuitarsPlaceHolder.Controls.Add(agc);

                if (acousticGuitarsCount > 1)
                {
                    Button button = new Button();
                    button.ID = "rm" + (i + 1).ToString();
                    button.Text = "Изтрий";
                    button.Click += new EventHandler(RemoveAG);
                    button.CausesValidation = false;
                    AcousticGuitarsPlaceHolder.Controls.Add(button);
                }
            }
        }

        private void initClassicalGuitars()
        {
            dynamicClassicalGuitars = new List<ClassicalGuitarControl>();
            for (int i = 0; i < classicalGuitarsCount; i++)
            {
                ClassicalGuitarControl cgc = LoadControl("~/ClassicalGuitarControl.ascx") as ClassicalGuitarControl;
                cgc.ID = "cg" + (i + 1).ToString();
                dynamicClassicalGuitars.Add(cgc);
                ClassicalGuitarsPlaceHolder.Controls.Add(cgc);

                if (classicalGuitarsCount > 1)
                {
                    Button button = new Button();
                    button.ID = "rm" + (i + 1).ToString();
                    button.Text = "Изтрий";
                    button.Click += new EventHandler(RemoveCG);
                    button.CausesValidation = false;
                    ClassicalGuitarsPlaceHolder.Controls.Add(button);
                }
            }
        }

        private void initAmplifiers()
        {
            dynamicAmplifiers = new List<AmplifierControl>();
            for (int i = 0; i < amplifiersCount; i++)
            {
                AmplifierControl amp = LoadControl("~/AmplifierControl.ascx") as AmplifierControl;
                amp.ID = "amp" + (i + 1).ToString();
                dynamicAmplifiers.Add(amp);
                AmplifiersPlaceHolder.Controls.Add(amp);

                if (amplifiersCount > 1)
                {
                    Button button = new Button();
                    button.ID = "rm" + (i + 1).ToString();
                    button.Text = "Изтрий";
                    button.Click += new EventHandler(RemoveAMP);
                    button.CausesValidation = false;
                    AmplifiersPlaceHolder.Controls.Add(button);
                }
            }
        }

        private void initStrings()
        {
            dynamicStrings = new List<StringsControl>();
            for (int i = 0; i < stringsCount; i++)
            {
                StringsControl strc = LoadControl("~/StringsControl.ascx") as StringsControl;
                strc.ID = "str" + (i + 1).ToString();
                dynamicStrings.Add(strc);
                StringsPlaceHolder.Controls.Add(strc);

                if (stringsCount > 1)
                {
                    Button button = new Button();
                    button.ID = "rm" + (i + 1).ToString();
                    button.Text = "Изтрий";
                    button.Click += new EventHandler(RemoveSTR);
                    button.CausesValidation = false;
                    StringsPlaceHolder.Controls.Add(button);
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            initElectricGuitars();
            initAcousticGuitars();
            initClassicalGuitars();
            initAmplifiers();
            initStrings();
        }

        protected void RemoveEG(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int contorlNumber = int.Parse(Regex.Match(clicked.ClientID, @"\d+").ToString());
            if (contorlNumber != elelectricGuitarsCount)
                while (true)
                {
                    ElectricGuitarControl eg = ElectricGuitarsPlaceHolder.FindControl(("eg" +  contorlNumber.ToString())) as ElectricGuitarControl;
                    ElectricGuitarControl nexteg = ElectricGuitarsPlaceHolder.FindControl(("eg" + (contorlNumber + 1).ToString())) as ElectricGuitarControl;
                    eg.manufacturer = nexteg.manufacturer;
                    eg.model = nexteg.model; 
                    eg.description = nexteg.description;
                    eg.guitarID = nexteg.guitarID;
                    eg.GuitarShopID = nexteg.GuitarShopID;
                    eg.price_value = nexteg.price_value;
                    eg.price_currency = nexteg.price_currency;
                    eg.body = nexteg.body;
                    eg.number_strings = nexteg.number_strings;
                    eg.number_frets = nexteg.number_frets;
                    eg.pickguard = nexteg.pickguard;
                    eg.tremolo = nexteg.tremolo;
                    eg.neckpickup = nexteg.neckpickup;
                    eg.middlepickup = nexteg.middlepickup;
                    eg.bridgepickup = nexteg.bridgepickup;
                    contorlNumber++;
                    if (contorlNumber == elelectricGuitarsCount) break;
                }
            Control egControl = ElectricGuitarsPlaceHolder.FindControl(("eg" + contorlNumber.ToString()));
            ElectricGuitarsPlaceHolder.Controls.Remove(egControl);
            dynamicElectricGuitars.Remove(egControl as ElectricGuitarControl);
            Control rmButton = ElectricGuitarsPlaceHolder.FindControl("rm" + contorlNumber.ToString());
            ElectricGuitarsPlaceHolder.Controls.Remove(rmButton);
            if (contorlNumber == 2)
            {
                rmButton = ElectricGuitarsPlaceHolder.FindControl("rm1");
                ElectricGuitarsPlaceHolder.Controls.Remove(rmButton);
            }
            elelectricGuitarsCount--;
        }

        protected void RemoveAG(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int contorlNumber = int.Parse(Regex.Match(clicked.ClientID, @"\d+").ToString());
            if (contorlNumber != acousticGuitarsCount)
                while (true)
                {
                    AcousticGuitarControl ag = AcousticGuitarsPlaceHolder.FindControl(("ag" + contorlNumber.ToString())) as AcousticGuitarControl;
                    AcousticGuitarControl nextag = AcousticGuitarsPlaceHolder.FindControl(("ag" + (contorlNumber + 1).ToString())) as AcousticGuitarControl;
                    ag.manufacturer = nextag.manufacturer;
                    ag.model = nextag.model;
                    ag.description = nextag.description;
                    ag.guitarID = nextag.guitarID;
                    ag.GuitarShopID = nextag.GuitarShopID;
                    ag.price_value = nextag.price_value;
                    ag.price_currency = nextag.price_currency;
                    ag.body = nextag.body;
                    ag.number_strings = nextag.number_strings;
                    contorlNumber++;
                    if (contorlNumber == acousticGuitarsCount) break;
                }
            Control agControl = AcousticGuitarsPlaceHolder.FindControl(("ag" + contorlNumber.ToString()));
            AcousticGuitarsPlaceHolder.Controls.Remove(agControl);
            dynamicAcousticGuitars.Remove(agControl as AcousticGuitarControl);
            Control rmButton = AcousticGuitarsPlaceHolder.FindControl("rm" + contorlNumber.ToString());
            AcousticGuitarsPlaceHolder.Controls.Remove(rmButton);
            if (contorlNumber == 2)
            {
                rmButton = AcousticGuitarsPlaceHolder.FindControl("rm1");
                AcousticGuitarsPlaceHolder.Controls.Remove(rmButton);
            }
            acousticGuitarsCount--;
        }

        protected void RemoveCG(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int contorlNumber = int.Parse(Regex.Match(clicked.ClientID, @"\d+").ToString());
            if (contorlNumber != classicalGuitarsCount)
                while (true)
                {
                    ClassicalGuitarControl cg = ClassicalGuitarsPlaceHolder.FindControl(("cg" + contorlNumber.ToString())) as ClassicalGuitarControl;
                    ClassicalGuitarControl nextcg = ClassicalGuitarsPlaceHolder.FindControl(("cg" + (contorlNumber + 1).ToString())) as ClassicalGuitarControl;
                    cg.manufacturer = nextcg.manufacturer;
                    cg.model = nextcg.model;
                    cg.description = nextcg.description;
                    cg.guitarID = nextcg.guitarID;
                    cg.GuitarShopID = nextcg.GuitarShopID;
                    cg.price_value = nextcg.price_value;
                    cg.price_currency = nextcg.price_currency;
                    contorlNumber++;
                    if (contorlNumber == classicalGuitarsCount) break;
                }
            Control cgControl = ClassicalGuitarsPlaceHolder.FindControl(("cg" + contorlNumber.ToString()));
            ClassicalGuitarsPlaceHolder.Controls.Remove(cgControl);
            dynamicClassicalGuitars.Remove(cgControl as ClassicalGuitarControl);
            Control rmButton = ClassicalGuitarsPlaceHolder.FindControl("rm" + contorlNumber.ToString());
            ClassicalGuitarsPlaceHolder.Controls.Remove(rmButton);
            if (contorlNumber == 2)
            {
                rmButton = ClassicalGuitarsPlaceHolder.FindControl("rm1");
                ClassicalGuitarsPlaceHolder.Controls.Remove(rmButton);
            }
            classicalGuitarsCount--;
        }

        protected void RemoveAMP(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int contorlNumber = int.Parse(Regex.Match(clicked.ClientID, @"\d+").ToString());
            if (contorlNumber != amplifiersCount)
                while (true)
                {
                    AmplifierControl amp = AmplifiersPlaceHolder.FindControl(("amp" + contorlNumber.ToString())) as AmplifierControl;
                    AmplifierControl nextamp = AmplifiersPlaceHolder.FindControl(("amp" + (contorlNumber + 1).ToString())) as AmplifierControl;
                    amp.manufacturer = nextamp.manufacturer;
                    amp.model = nextamp.model;
                    amp.description = nextamp.description;
                    amp.ampID = nextamp.ampID;
                    amp.GuitarShopID = nextamp.GuitarShopID;
                    amp.price_value = nextamp.price_value;
                    amp.price_currency = nextamp.price_currency;
                    amp.power = nextamp.power;
                    amp.power_unit = nextamp.power_unit;
                    contorlNumber++;
                    if (contorlNumber == amplifiersCount) break;
                }
            Control ampControl = AmplifiersPlaceHolder.FindControl(("amp" + contorlNumber.ToString()));
            AmplifiersPlaceHolder.Controls.Remove(ampControl);
            dynamicAmplifiers.Remove(ampControl as AmplifierControl);
            Control rmButton = AmplifiersPlaceHolder.FindControl("rm" + contorlNumber.ToString());
            AmplifiersPlaceHolder.Controls.Remove(rmButton);
            if (contorlNumber == 2)
            {
                rmButton = AmplifiersPlaceHolder.FindControl("rm1");
                AmplifiersPlaceHolder.Controls.Remove(rmButton);
            }
            amplifiersCount--;
        }

        protected void RemoveSTR(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int contorlNumber = int.Parse(Regex.Match(clicked.ClientID, @"\d+").ToString());
            if (contorlNumber != stringsCount)
                while (true)
                {
                    StringsControl str = StringsPlaceHolder.FindControl(("str" + contorlNumber.ToString())) as StringsControl;
                    StringsControl nextstr = StringsPlaceHolder.FindControl(("str" + (contorlNumber + 1).ToString())) as StringsControl;
                    str.manufacturer = nextstr.manufacturer;
                    str.description = nextstr.description;
                    str.stringsID = nextstr.stringsID;
                    str.GuitarShopID = nextstr.GuitarShopID;
                    str.price_value = nextstr.price_value;
                    str.price_currency = nextstr.price_currency;
                    str.gauge = nextstr.gauge;
                    contorlNumber++;
                    if (contorlNumber == stringsCount) break;
                }
            Control strControl = StringsPlaceHolder.FindControl(("str" + contorlNumber.ToString()));
            StringsPlaceHolder.Controls.Remove(strControl);
            dynamicAmplifiers.Remove(strControl as AmplifierControl);
            Control rmButton = StringsPlaceHolder.FindControl("rm" + contorlNumber.ToString());
            StringsPlaceHolder.Controls.Remove(rmButton);
            if (contorlNumber == 2)
            {
                rmButton = StringsPlaceHolder.FindControl("rm1");
                StringsPlaceHolder.Controls.Remove(rmButton);
            }
            stringsCount--;
        }

        protected void showSubmForm_Click(object sender, EventArgs e)
        {
            DivForm.Visible = true;
        }

        protected void ValidateGuitarShopID(object source, ServerValidateEventArgs args)
        {
            Int32 guitarshopID = Int32.Parse(args.Value);
            if (Regex.IsMatch(guitarshopID.ToString(), @"^\d+$"))
            {
                GuitarShopEntities6 context = new GuitarShopEntities6();
                var guitarshopIDs =
                    from gs in context.GuitarShops
                    select gs.GuitarShopID;
                if (!guitarshopIDs.Any(gs => gs == guitarshopID))
                    args.IsValid = true;
                else
                {
                    CustomValidatorGuitarShopID.ErrorMessage = "* Съществуващо ID";
                    args.IsValid = false;
                }
            }
            else
            {
                CustomValidatorGuitarShopID.ErrorMessage = "* Невалидно ID";
                args.IsValid = false;
            }

        }

        protected void ValidateGuitarShopName(object source, ServerValidateEventArgs args)
        {
            string guitarshopName = args.Value;
            if (Regex.IsMatch(guitarshopName, @"[\./\\\+,;':""]")) args.IsValid = false;
            else args.IsValid = true;
        }

        protected void ValidatePhone(object source, ServerValidateEventArgs args)
        {
            string phone = args.Value;
            if (!Regex.IsMatch(phone, @"^[0-9]+$") || phone.Length > 12) args.IsValid = false;
            else args.IsValid = true;
        }

        protected void LBtnAddMore_Click(object sender, EventArgs e)
        {
            elelectricGuitarsCount = 1;
            classicalGuitarsCount = 1;
            acousticGuitarsCount = 1;
            amplifiersCount = 1;
            stringsCount = 1;
            Response.Redirect("DataInput.aspx");
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                XMLCreator creator = new XMLCreator();
                GuitarShopEntities6 context = new GuitarShopEntities6();
                GuitarShops gs = new GuitarShops();
                gs.GuitarShopID = Int32.Parse(InputGuitarShopID.Text);
                gs.name = InputGuitarShopName.Text;
                Contacts con = new Contacts();
                con.adress = InputAdress.Text;
                con.guitar_shopID = Int32.Parse(InputGuitarShopID.Text);
                con.phone = InputPhone.Text;
                con.email = InputEmail.Text;
                con.website = InputWebsite.Text;
                gs.Contacts.Add(con);
                ElectricGuitars electricguitar;
                foreach (ElectricGuitarControl egc in dynamicElectricGuitars)
                {
                    electricguitar = new ElectricGuitars();
                    egc.fillProperties(electricguitar, gs.GuitarShopID);
                    gs.ElectricGuitars.Add(electricguitar);
                }
                AcousticGuitars acousticguitar;
                foreach (AcousticGuitarControl agc in dynamicAcousticGuitars)
                {
                    acousticguitar = new AcousticGuitars();
                    agc.fillProperties(acousticguitar, gs.GuitarShopID);
                    gs.AcousticGuitars.Add(acousticguitar);
                }
                ClassicalGuitars classicalguitar;
                foreach (ClassicalGuitarControl cgc in dynamicClassicalGuitars)
                {
                    classicalguitar = new ClassicalGuitars();
                    cgc.fillProperties(classicalguitar, gs.GuitarShopID);
                    gs.ClassicalGuitars.Add(classicalguitar);
                }
                Amplifiers amplifier;
                foreach (AmplifierControl ampc in dynamicAmplifiers)
                {
                    amplifier = new Amplifiers();
                    ampc.fillProperties(amplifier, gs.GuitarShopID);
                    gs.Amplifiers.Add(amplifier);
                }
                Strings strings;
                foreach (StringsControl sc in dynamicStrings)
                {
                    strings = new Strings();
                    sc.fillProperties(strings, gs.GuitarShopID);
                    gs.Strings.Add(strings);
                }                   
                creator.CreateGuitarShopXMLDocument(Server.MapPath("~/App_Data/" + gs.name + gs.GuitarShopID + ".xml"), "kitari.dtd", gs);
                context.GuitarShops.AddObject(gs);
                context.SaveChanges();
                DivSuccess.Visible = true;
                DivForm.Visible = false;

            }
        }

        protected void btnAddElectricGuitar_Click(object sender, EventArgs e)
        {
            // Handled in preInit due to event sequencing.
        }

        protected void btnAddAcousticGuitar_Click(object sender, EventArgs e)
        {
            // Handled in preInit due to event sequencing.
        }

        protected void btnAddClassicalGuitar_Click(object sender, EventArgs e)
        {
            // Handled in preInit due to event sequencing.
        }

        protected void btnAddAmplifier_Click(object sender, EventArgs e)
        {
            // Handled in preInit due to event sequencing.
        }

        protected void btnAddStrings_Click(object sender, EventArgs e)
        {
            // Handled in preInit due to event sequencing.
        }

    }
}