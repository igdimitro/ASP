using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Schema;

namespace GuitarShop.App_Code
{
    public class XMLCreator
    {
        private XmlDocument xml = new XmlDocument();
        private string path;
        private string dtdFile;

        private void AddAttribute(XmlNode XMLNode, string attrName, string attrValue)
        {
            XmlAttribute attr = xml.CreateAttribute(attrName);
            attr.Value = attrValue;
            XMLNode.Attributes.Append(attr);
        }

        private void AddAttribute(string xPath, string attrName, string attrValue)
        {
            XmlAttribute attr = xml.CreateAttribute(attrName);
            attr.Value = attrValue;
            xml.SelectSingleNode(xPath).Attributes.Append(attr);
        }

        private void AddNode(XmlNode XMLNode, string childName, string innerText)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, childName, null);
            node.InnerText = innerText;
            XMLNode.AppendChild(node);
        }

        private void AddNode(string xPath, string childName, string innerText)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, childName, null);
            node.InnerText = innerText;
            xml.SelectSingleNode(xPath).AppendChild(node);
        }

        private XmlNode AddNodeAndReturnIt(XmlNode XMLNode, string childName, string innerText)
        {           
            XmlNode node = xml.CreateNode(XmlNodeType.Element, childName, null);
            node.InnerText = innerText;
            XMLNode.AppendChild(node);
            return node;
        }

        private XmlNode AddNodeAndReturnIt(string xPath, string childName, string innerText)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, childName, null);
            node.InnerText = innerText;
            xml.SelectSingleNode(xPath).AppendChild(node);
            return node;
        }

        private void CreateRootElem(string name, string id)
        {
            XmlNode node = xml.CreateElement("guitar_shop");
            AddAttribute(node, "GuitarShopID", id);
            AddAttribute(node, "name", name);
            xml.AppendChild(node);
            xml.Save(this.path);
        }

        private void addContacts(List<Contacts> con)
        {
            AddNode("/guitar_shop", "contacts", null);
            if (con[0].adress != null)
                AddNode("/guitar_shop/contacts", "adress", con[0].adress);
            AddNode("/guitar_shop/contacts", "phone", con[0].phone);
            AddNode("/guitar_shop/contacts", "email", con[0].email);
            AddNode("/guitar_shop/contacts", "website", con[0].website);
        }

        private void addGuitars(List<ElectricGuitars> egs, List<ClassicalGuitars> cgs, List<AcousticGuitars> ags)
        {
            AddNode("/guitar_shop", "guitars", null);
            addElectricGuitars(egs);
            addClassicalGuitars(cgs);
            addAcousticlGuitars(ags);
        }

        private void addAmplifiers(List<Amplifiers> amps)
        {
            if (amps.Count > 0)
            {
                AddNode("/guitar_shop", "amplifiers", null);
                foreach (Amplifiers amp in amps)
                {
                    XmlNode ampNode = AddNodeAndReturnIt("/guitar_shop/amplifiers", "amplifier", null);
                    AddAttribute(ampNode, "manufacturer", amp.manufacturer);
                    AddAttribute(ampNode, "model", amp.model);
                    AddAttribute(ampNode, "type", amp.amplifier_type);
                    XmlNode price = AddNodeAndReturnIt(ampNode, "price", null);
                    AddAttribute(price, "value", amp.price_value.ToString());
                    AddAttribute(price, "currency", amp.price_currency);
                    AddNode(ampNode, "description", amp.description);                    
                    XmlNode power = AddNodeAndReturnIt(ampNode, "power", null);
                    AddAttribute(power, "value", amp.power.ToString());
                    AddAttribute(power, "unit", amp.power_unit);
                }
            }
            
        }

        private void addStrings(List<Strings> strings)
        {
            if (strings.Count > 0)
            {
                AddNode("/guitar_shop", "strings", null);
                foreach (Strings str in strings)
                {
                    if (str.strings_type == "acoustic_guitar_strings")
                    {
                        XmlNode agsnode = AddNodeAndReturnIt("/guitar_shop/strings", "acoustic_guitar_strings", null);
                        AddAttribute(agsnode, "manufacturer", str.manufacturer);
                        AddAttribute(agsnode, "gauge", str.gauge.ToString());
                        XmlNode price = AddNodeAndReturnIt(agsnode, "price", null);
                        AddAttribute(price, "value", str.price_value.ToString());
                        AddAttribute(price, "currency", str.price_currency);
                        AddNode(agsnode, "description", str.description);                 

                    }
                    else if (str.strings_type == "electric_guitar_strings")
                    {
                        XmlNode egsnode = AddNodeAndReturnIt("/guitar_shop/strings", "electric_guitar_strings", null);
                        AddAttribute(egsnode, "manufacturer", str.manufacturer);
                        AddAttribute(egsnode, "gauge", str.gauge.ToString());
                        XmlNode price = AddNodeAndReturnIt(egsnode, "price", null);
                        AddAttribute(price, "value", str.price_value.ToString());
                        AddAttribute(price, "currency", str.price_currency);
                        AddNode(egsnode, "description", str.description);                        
                    }
                    else if (str.strings_type == "classical_guitar_strings")
                    {
                        XmlNode cgsnode = AddNodeAndReturnIt("/guitar_shop/strings", "classical_guitar_strings", null);
                        AddAttribute(cgsnode, "manufacturer", str.manufacturer);
                        AddAttribute(cgsnode, "gauge", str.gauge.ToString());
                        XmlNode price = AddNodeAndReturnIt(cgsnode, "price", null);
                        AddAttribute(price, "value", str.price_value.ToString());
                        AddAttribute(price, "currency", str.price_currency);
                        AddNode(cgsnode, "description", str.description);                        
                    }
                }
            }
        }
        

        private void addElectricGuitars(List<ElectricGuitars> electricguitars)
        {

            foreach (ElectricGuitars eg in electricguitars)
            {
                XmlNode guitarNode = AddNodeAndReturnIt("/guitar_shop/guitars", "guitar", null);
                XmlNode guitarsNode = AddNodeAndReturnIt(guitarNode, "electric_guitar", null);
                AddAttribute(guitarsNode, "manufacturer", eg.manufacturer);
                AddAttribute(guitarsNode, "model", eg.model);
                AddAttribute(guitarsNode, "num_strings", eg.number_strings.ToString());
                AddAttribute(guitarsNode, "num_frets", eg.number_frets.ToString());                
                AddNode(guitarsNode, "description", eg.description);
                XmlNode price = AddNodeAndReturnIt(guitarsNode, "price", null);
                AddAttribute(price, "value", eg.price_value.ToString());
                AddAttribute(price, "currency", eg.price_currency);
                XmlNode body = AddNodeAndReturnIt(guitarsNode, "body", null);
                if (eg.body == "Telecaster" || eg.body == "Stratocaster" || eg.body == "SG" ||
                    eg.body == "Les_Paul" || eg.body == "Jazzmaster" || eg.body == "Explorer" || eg.body == "Flying_V")
                {
                    XmlNode solid_body = AddNodeAndReturnIt(body, "solid_body", null);
                    AddAttribute(solid_body, "body_type", eg.body);
                }
                else if (eg.body == "Fully_Hollow" || eg.body == "Semi_Hollow" || eg.body == "Other" )
                {
                    XmlNode hollow_body = AddNodeAndReturnIt(body, "hollow_body", null);
                    AddAttribute(hollow_body, "body_type", eg.body);
                }
                XmlNode pickups = AddNodeAndReturnIt(guitarsNode, "pickups", null);
                List<Pickups> pickupsList = eg.Pickups.ToList<Pickups>();
                foreach (Pickups pickupitem in pickupsList)
                {
                    XmlNode p = AddNodeAndReturnIt(pickups, "pickup", null);
                    XmlNode pickuptype = AddNodeAndReturnIt(p, "pickup_type", null);
                    if (pickupitem.pickup_type == "humbucker" || pickupitem.pickup_type == "single-coil")
                    {
                        XmlNode magneticpickup = AddNodeAndReturnIt(pickuptype, "magnetic", null);
                        AddAttribute(magneticpickup, "type", pickupitem.pickup_type);
                    }
                    else if (pickupitem.pickup_type.Equals("piezoelectric"))
                    {
                        AddNode(pickuptype, "piezoelectric", null);
                    }
                    else if (pickupitem.pickup_type.Equals("optical"))
                    {
                        AddNode(pickuptype, "optical", null);
                    }
                    XmlNode pickuppos = AddNodeAndReturnIt(p, "position", null);
                    AddAttribute(pickuppos, "pos", pickupitem.pickup_position);
                }

                if (eg.pickguard != null)
                    AddNode(guitarsNode, "pickguard", eg.pickguard);
                if (eg.tremolo != null)
                    AddNode(guitarsNode, "tremolo_bar", eg.tremolo);
            }
        }

        private void addClassicalGuitars(List<ClassicalGuitars> classicalguitars)
        {
            foreach (ClassicalGuitars cg in classicalguitars)
            {
                XmlNode guitarsNode = AddNodeAndReturnIt("/guitar_shop/guitars", "guitar", null);
                XmlNode acoustic = AddNodeAndReturnIt(guitarsNode, "acoustic_guitar", null);
                AddAttribute(acoustic, "electro-acoustic", cg.electro_acoustic);
                XmlNode guitarNode = AddNodeAndReturnIt(acoustic, "classical_guitar", null);
                AddAttribute(guitarNode, "manufacturer", cg.manufacturer);
                AddAttribute(guitarNode, "model", cg.model);
                XmlNode price = AddNodeAndReturnIt(guitarNode, "price", null);
                AddAttribute(price, "value", cg.price_value.ToString());
                AddAttribute(price, "currency", cg.price_currency);
                AddNode(guitarNode, "description", cg.description);
            }
        }

        private void addAcousticlGuitars(List<AcousticGuitars> acousticguitars)
        {
            foreach (AcousticGuitars ag in acousticguitars)
            {
                XmlNode guitarsNode = AddNodeAndReturnIt("/guitar_shop/guitars", "guitar", null);
                XmlNode acoustic = AddNodeAndReturnIt(guitarsNode, "acoustic_guitar", null);
                AddAttribute(acoustic, "electro-acoustic", ag.electro_acoustic);
                XmlNode guitarNode = AddNodeAndReturnIt(acoustic, "steel-stringed", null);
                AddAttribute(guitarNode, "manufacturer", ag.manufacturer);
                AddAttribute(guitarNode, "model", ag.model);
                AddAttribute(guitarNode, "num_strings", ag.number_strings.ToString());
                XmlNode price = AddNodeAndReturnIt(guitarNode, "price", null);
                AddAttribute(price, "value", ag.price_value.ToString());
                AddAttribute(price, "currency", ag.price_currency);
                XmlNode body_type = AddNodeAndReturnIt(guitarNode, "body_type", null);
                AddAttribute(body_type, "body", ag.body);
                AddNode(guitarNode, "description", ag.description);
            }
        }

        private void Save()
        {
            this.xml.Save(this.path);
        }

        private void AddDTD(string systemId)
        {
            if (!Regex.IsMatch(systemId, @"^\w+\.dtd$"))
            {
                throw new DTDException("Both the DTD and the XML files must be in the same" +
                    "directory and the parameter \"systemId\" must match the pattern <file_name>.dtd");
            }
            else
            {
                xml.Load(this.path);
                XmlElement root = xml.DocumentElement;
                XmlDeclaration xmlDecl = xml.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlDocumentType docType = xml.CreateDocumentType("guitar_shop", null, systemId, null);
                xml.InsertBefore(xmlDecl, root);
                xml.InsertBefore(docType, root);
            }
        }

        public bool CreateGuitarShopXMLDocument(string path, string dtdFileName, GuitarShops shop)
        {
            this.path = path;
            this.dtdFile = dtdFileName;
            if(shop == null)
                throw new XMLCreatorException("The parameter \"shop\" can not be null");
            try
            {
                if (shop.Strings.Count == 0 && shop.ElectricGuitars.Count == 0 && shop.Amplifiers.Count == 0 &&
                    shop.AcousticGuitars.Count == 0 && shop.ClassicalGuitars.Count == 0)
                {
                    throw new XMLCreatorException("You must click on at least one of the buttons, which add the required fields!");
                }
                CreateRootElem(shop.name, "GS" + shop.GuitarShopID.ToString());
                AddDTD(this.dtdFile);
                addContacts(shop.Contacts.ToList<Contacts>());
                addGuitars(shop.ElectricGuitars.ToList<ElectricGuitars>(),
                           shop.ClassicalGuitars.ToList<ClassicalGuitars>(),
                           shop.AcousticGuitars.ToList<AcousticGuitars>());
                addAmplifiers(shop.Amplifiers.ToList<Amplifiers>());
                if (shop.Strings != null)
                    addStrings(shop.Strings.ToList<Strings>());
                Save();
            }
            catch (Exception e)
            {
                throw new XMLCreatorException(e.Message);
            }
            return true;    
        }


    }
}