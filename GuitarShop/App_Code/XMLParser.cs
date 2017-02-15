using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace GuitarShop.App_Code
{
    public class XMLParser
    {
        private GuitarShops shops;
        private XmlDocument xml = new XmlDocument();
        private string path;

        private void LoadXML(string path)
        {
            this.xml.Load(path);
        }

        private void InitGuitarShop() //sets the attributes name and ID...
        {
            XmlNode guitar_shop = xml.SelectSingleNode("/guitar_shop");
            this.shops = new GuitarShops();
            string GSID_full = guitar_shop.Attributes["GuitarShopID"].Value; 
            int guitarShopID = Int32.Parse(GSID_full.Substring(2)); //drop the first 2 characters as they are "GS" and are not parseble to int...
            shops.GuitarShopID = guitarShopID;
            int nameLength = guitar_shop.Attributes["name"].Value.Length;
            shops.name = nameLength > 128 ? guitar_shop.Attributes["name"].Value.Substring(0, 128) : guitar_shop.Attributes["name"].Value;
        }

        private void GetContacts()
        {
            Contacts c = new Contacts();
            XmlNode contacts = xml.SelectSingleNode("/guitar_shop/contacts");
            XmlNodeList contacts_subelems = contacts.ChildNodes;
            c.guitar_shopID = shops.GuitarShopID;
            foreach (XmlNode nod in contacts_subelems)
            {
                switch (nod.Name.ToString())
                { 
                    case "adress":
                        int adressLength = nod.InnerText.Length;
                        c.adress = adressLength > 256 ? nod.InnerText.Substring(0, 256) : nod.InnerText;
                        break;
                    case "phone":
                        int phoneLength = nod.InnerText.Length;
                        c.phone = phoneLength > 12 ? nod.InnerText.Substring(0, 12) : nod.InnerText;
                        break;
                    case "email":
                        int emailLength = nod.InnerText.Length;
                        c.email = emailLength > 32 ? nod.InnerText.Substring(0, 32) : nod.InnerText;
                        break;
                    case "website":
                        int websiteLength = nod.InnerText.Length;
                        c.website = websiteLength > 128 ? nod.InnerText.Substring(0, 128) : nod.InnerText;
                        break;
                }
            }
            this.shops.Contacts.Add(c);
        }

        private AcousticGuitars getAcousticGuitar(XmlNode n)
        {
                AcousticGuitars ag = new AcousticGuitars();
                ag.GuitarShopID = shops.GuitarShopID;
                XmlNode acoustic = n.ParentNode;
                ag.electro_acoustic = acoustic.Attributes["electro-acoustic"].Value;
                int manufacturerLength = n.Attributes["manufacturer"].Value.Length;
                ag.manufacturer = manufacturerLength > 20 ? n.Attributes["manufacturer"].Value.Substring(0, 20) : n.Attributes["manufacturer"].Value;
                int modelLength = n.Attributes["model"].Value.Length;
                ag.model = modelLength > 20 ? n.Attributes["model"].Value.Substring(0, 20) : n.Attributes["model"].Value;
                ag.number_strings = Byte.Parse(n.Attributes["num_strings"].Value);

                XmlNodeList list = n.ChildNodes;
                foreach (XmlNode nod in list)
                {
                    switch (nod.Name.ToString())
                    {
                        case "body_type":
                            int bodyLength = nod.Attributes["body"].Value.Length;
                            ag.body = bodyLength > 11 ? nod.Attributes["body"].Value.Substring(0, 11) : nod.Attributes["body"].Value;
                            break;
                        case "description":
                            int descLen = nod.InnerText.Length;
                            ag.description = descLen > 400 ? nod.InnerText.Substring(0, 400) : nod.InnerText;
                            break;
                        case "price":
                            ag.price_value = Double.Parse(nod.Attributes["value"].Value);
                            ag.price_currency = nod.Attributes["currency"].Value;
                            break;
                    }
                }
                return ag;
        }

        private void GetAcousticGuitars()
        {
            XmlNodeList acoustic_guitar_nodes = xml.GetElementsByTagName("steel-stringed");
            if (acoustic_guitar_nodes != null)
            { 
                foreach(XmlNode node in acoustic_guitar_nodes)
                {
                    this.shops.AcousticGuitars.Add(this.getAcousticGuitar(node));
                }
            }
        }

        private ClassicalGuitars getClassicalGuitar(XmlNode n)
        {
                ClassicalGuitars cg = new ClassicalGuitars();
                cg.GuitarShopID = shops.GuitarShopID;
                XmlNode acoustic_guitar = n.ParentNode;
                cg.electro_acoustic = acoustic_guitar.Attributes["electro-acoustic"].Value;
                int manufacturerLength = n.Attributes["manufacturer"].Value.Length;
                cg.manufacturer = manufacturerLength > 20 ? n.Attributes["manufacturer"].Value.Substring(0, 20) : n.Attributes["manufacturer"].Value;
                int modelLength = n.Attributes["model"].Value.Length;
                cg.model = modelLength > 20 ? n.Attributes["model"].Value.Substring(0, 20) : n.Attributes["model"].Value;

                XmlNodeList list = n.ChildNodes;
                foreach (XmlNode nod in list)
                {
                    switch (nod.Name.ToString())
                    {
                        case "description":
                            int descLen = nod.InnerText.Length;
                            cg.description = descLen > 400 ? nod.InnerText.Substring(0, 400) : nod.InnerText;
                            break;
                        case "price":
                            cg.price_value = Double.Parse(nod.Attributes["value"].Value);
                            cg.price_currency = nod.Attributes["currency"].Value;
                            break;
                    }
                }
                return cg;
        }

        private void GetClassicalGuitars()
        {
            XmlNodeList acoustic_guitar_nodes = xml.GetElementsByTagName("classical_guitar");
            if (acoustic_guitar_nodes != null)
            {
                foreach (XmlNode node in acoustic_guitar_nodes)
                {
                    this.shops.ClassicalGuitars.Add(this.getClassicalGuitar(node));
                }
            }
        }

        private ElectricGuitars getElectricGuitar(XmlNode n)
        {
                ElectricGuitars eg = new ElectricGuitars();
                eg.GuitarShopID = shops.GuitarShopID;
                int manufacturerLength = n.Attributes["manufacturer"].Value.Length;
                eg.manufacturer = manufacturerLength > 20 ? n.Attributes["manufacturer"].Value.Substring(0, 20) : n.Attributes["manufacturer"].Value;
                int modelLength = n.Attributes["model"].Value.Length;
                eg.model = modelLength > 20 ? n.Attributes["model"].Value.Substring(0, 20) : n.Attributes["model"].Value;
                eg.number_strings = Byte.Parse(n.Attributes["num_strings"].Value);
                eg.number_frets = Byte.Parse(n.Attributes["num_frets"].Value);
                eg.pickguard = "Не";
                eg.tremolo = "Не";
                XmlNodeList list = n.ChildNodes;
                foreach (XmlNode nod in list)
                {
                    switch (nod.Name.ToString())
                    {
                        case "description":
                            int descLen = nod.InnerText.Length;
                            eg.description = descLen > 400 ? nod.InnerText.Substring(0, 400) : nod.InnerText;
                            break;
                        case "price":
                            eg.price_value = Double.Parse(nod.Attributes["value"].Value);
                            eg.price_currency = nod.Attributes["currency"].Value;
                            break;
                        case "body":
                            XmlNode body = nod.FirstChild;
                            eg.body = body.Attributes["body_type"].Value;
                            break;
                        case "pickups":
                            XmlNodeList pickups_list = nod.ChildNodes;
                            foreach (XmlNode pickup in pickups_list)
                            {
                                Pickups current_pickup = new Pickups();
                                XmlNode pickup_t = pickup.FirstChild; // magnetic, piezoelectric or optical
                                XmlNode pickup_type = pickup_t.FirstChild;
                                switch (pickup_type.Name.ToString())
                                {
                                    case "magnetic":
                                        current_pickup.pickup_type = pickup_type.Attributes["type"].Value;
                                        break;
                                    case "piezoelectric":
                                        current_pickup.pickup_type = "piezoelectric";
                                        break;
                                    case "optical":
                                        current_pickup.pickup_type = "optical";
                                        break;
                                }
                                XmlNode pickup_pos = pickup.LastChild;
                                current_pickup.pickup_position = pickup_pos.Attributes["pos"].Value;
                                eg.Pickups.Add(current_pickup);
                            }
                            break;
                        case "tremolo_bar":
                            eg.tremolo = "Да";
                            break;
                        case "pickguard":
                            eg.pickguard = "Да";
                            break;
                    }
                }
                return eg;
        }

        private void GetElectricGuitars()
        {
            XmlNodeList electric_guitar_nodes = xml.GetElementsByTagName("electric_guitar");
            if (electric_guitar_nodes != null)
            {
                foreach (XmlNode node in electric_guitar_nodes)
                {
                    this.shops.ElectricGuitars.Add(this.getElectricGuitar(node));
                }
            }
        }

        private Amplifiers getAmplifier(XmlNode n)
        {
            Amplifiers amp = new Amplifiers();
            amp.GuitarShopID = shops.GuitarShopID;
            int manufacturerLength = n.Attributes["manufacturer"].Value.Length;
            amp.manufacturer = manufacturerLength > 20 ? n.Attributes["manufacturer"].Value.Substring(0, 20) : n.Attributes["manufacturer"].Value;
            int modelLength = n.Attributes["model"].Value.Length;
            amp.model = modelLength > 20 ? n.Attributes["model"].Value.Substring(0, 20) : n.Attributes["model"].Value;
            amp.amplifier_type = n.Attributes["type"].Value;
            XmlNodeList amp_subelems = n.ChildNodes;
            foreach ( XmlNode nod in amp_subelems)
            {
                switch (nod.Name.ToString())
                {
                    case "description":
                        int descLen = nod.InnerText.Length;
                        amp.description = descLen > 400 ? nod.InnerText.Substring(0, 400) : nod.InnerText;
                        break;
                    case "price":
                        amp.price_value = Double.Parse(nod.Attributes["value"].Value);
                        amp.price_currency = nod.Attributes["currency"].Value;
                        break;
                    case "power":
                        amp.power = Double.Parse(nod.Attributes["value"].Value);
                        amp.power_unit = nod.Attributes["unit"].Value;
                        break;
                }
            }

            return amp;
        }

        private void GetAmplifiers()
        {
            XmlNodeList amplifier_nodes = xml.GetElementsByTagName("amplifier");
            if (amplifier_nodes != null)
            {
                foreach (XmlNode node in amplifier_nodes)
                {
                    this.shops.Amplifiers.Add(this.getAmplifier(node));
                }
            }
        }

        private void GetStrings()
        {
            XmlNode strings_node = xml.SelectSingleNode("/guitar_shop/strings");
            XmlNodeList all_strings = strings_node.ChildNodes;
            foreach (XmlNode strings in all_strings)
            {
                Strings current_strings = new Strings();
                current_strings.GuitarShopID = shops.GuitarShopID;
                int manLen = strings.Attributes["manufacturer"].Value.Length;
                current_strings.manufacturer = manLen > 20 ? strings.Attributes["manufacturer"].Value.Substring(0, 20) : strings.Attributes["manufacturer"].Value;
                current_strings.gauge = Double.Parse(strings.Attributes["gauge"].Value);
                XmlNodeList strings_subelems = strings.ChildNodes;
                foreach (XmlNode nod in strings_subelems)
                {
                    switch (nod.Name.ToString())
                    {
                        case "description":
                            int descLen = nod.InnerText.Length;
                            current_strings.description = descLen > 400 ? nod.InnerText.Substring(0, 400) : nod.InnerText;
                            break;
                        case "price":
                            current_strings.price_value = Double.Parse(nod.Attributes["value"].Value);
                            current_strings.price_currency = nod.Attributes["currency"].Value;
                            break;
                    }
                }

                switch (strings.Name.ToString())
                { 
                    case "acoustic_guitar_strings":
                        current_strings.strings_type = "acoustic_guitar_strings";
                        break;
                    case "electric_guitar_strings":
                        current_strings.strings_type = "electric_guitar_strings";
                        break;
                    case "classical_guitar_strings":
                        current_strings.strings_type = "classical_guitar_strings";
                        break;

                }

                this.shops.Strings.Add(current_strings);
            }            
        }

        public bool LoadGuitarShopFromXML(string path)
        {
            try
            {
                Validator val = new Validator();
                val.Validate(path);

                this.path = path;

                LoadXML(path);
                InitGuitarShop();
                GetContacts();
                GetElectricGuitars();
                GetAcousticGuitars();
                GetClassicalGuitars();
                GetAmplifiers();
                GetStrings();
            }
            catch (Exception e)
            {
                throw new XMLParserException(e.Message);
            }
            return true;
        }

        public GuitarShops GuitarShop
        {
            get
            {
                if (shops != null)
                    return this.shops;
                else throw new XMLParserException("You must first call the \"LoadGuitarShopFromXML(string path)\"  method for your XMLParser object!");
            }
        }

    }
}