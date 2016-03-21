using System;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace ValidateOrderXML
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class ValidateXML
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			// TODO: Add code to start application here
			//
			XmlValidatingReader reader  = null;
			XmlSchemaCollection myschema = new XmlSchemaCollection();
			ValidationEventHandler eventHandler =
				new ValidationEventHandler(ValidateXML.ShowCompileErrors );

			try
			{
				using( StreamReader xmlFile = File.OpenText(args[0]) )
				{
					//Create the XmlParserContext.
					XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);
					string xmlFragment = xmlFile.ReadToEnd();

					//Implement the reader. 
					reader = new XmlValidatingReader(xmlFragment, XmlNodeType.Element, context);
					//Add the schema.
					myschema.Add("http://tempuri.org/purchase order.xsd", args[1]);

					//Set the schema type and add the schema to the reader.
					reader.ValidationType = ValidationType.Schema;
					reader.Schemas.Add(myschema);

					while (reader.Read())
					{
					}
				}
				Console.WriteLine("Completed validating xmlfile.");
			}
			catch (XmlException XmlExp)
			{
				Console.WriteLine(XmlExp.Message);
			}
			catch(XmlSchemaException XmlSchExp)
			{
				Console.WriteLine(XmlSchExp.Message);
			}
			catch(Exception GenExp)
			{
				Console.WriteLine(GenExp.Message);
			}
			finally
			{
			}

		}
		public static void ShowCompileErrors(object sender, ValidationEventArgs args)
		{
			Console.WriteLine("Validation Error: {0}", args.Message);
		}
	}
}
