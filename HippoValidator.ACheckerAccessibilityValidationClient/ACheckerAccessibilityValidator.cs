using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace HippoValidator.ACheckerAccessibilityValidationClient
{
    public class ACheckerAccessibilityValidator : IACheckerAccessibilityValidator
    {
        private readonly string _apiKey;
        private readonly Regex _weirdCharsCompensator = new Regex("&[^\\s]*;");

        public ACheckerAccessibilityValidator(string apiKey)
        {
            _apiKey = apiKey;
        }

        public ValidationResult Validate(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentException("url cannot be null");
            }

            var webClient = new WebClient();
            var xml = webClient.DownloadString(string.Format("http://achecker.ca/checkacc.php?uri={0}&id={1}&output=rest", url, _apiKey));
            xml = _weirdCharsCompensator.Replace(xml, string.Empty);
            var xmlReader = XmlReader.Create(new MemoryStream(Encoding.ASCII.GetBytes(xml)),
                                             new XmlReaderSettings {DtdProcessing = DtdProcessing.Parse});
            var document = XDocument.Load(xmlReader);
            var results = from result in document.Descendants("result")
                          select new
                              {
                                  Type = result.Element("resultType").Value,
                                  LineNumber = int.Parse(result.Element("lineNum").Value),
                                  ColumnNumber = int.Parse(result.Element("columnNum").Value),
                                  ErrorMessage = result.Element("errorMsg").Value.Substring(1 + result.Element("errorMsg").Value.LastIndexOf("=")),
                                  SourceCode = result.Element("errorSourceCode") != null ? result.Element("errorSourceCode").Value : null,
                              };

            return new ValidationResult
                {
                    Errors = results
                        .Where(x => x.Type == "Error")
                        .Select(
                            x =>
                            new ValidationIssue
                                {
                                    Title = x.ErrorMessage,
                                    Column = x.ColumnNumber,
                                    Row = x.LineNumber,
                                    Source = x.SourceCode
                                })
                        .ToList(),
                    Warnings = results
                        .Where(x => x.Type == "Warning")
                        .Select(
                            x =>
                            new ValidationIssue
                                {
                                    Title = x.ErrorMessage,
                                    Column = x.ColumnNumber,
                                    Row = x.LineNumber,
                                    Source = x.SourceCode
                                })
                        .ToList()
                };
        }
    }
}