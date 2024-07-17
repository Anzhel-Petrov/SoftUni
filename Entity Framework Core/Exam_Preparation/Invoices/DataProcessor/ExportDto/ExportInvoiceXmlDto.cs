using System.Xml.Serialization;
using Invoices.Data.Models.Enums;

namespace Invoices.DataProcessor.ExportDto;

[XmlType("Invoice")]
public class ExportInvoiceXmlDto
{
    [XmlElement("InvoiceNumber")] public int InvoiceNumber { get; set; }
    [XmlElement("InvoiceAmount")] public double InvoiceAmount { get; set; }
    [XmlElement("DueDate")] public string DueDate { get; set; } = null!;
    [XmlElement("Currency")] public string Currency { get; set; }  = null!;
}