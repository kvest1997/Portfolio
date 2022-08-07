using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ProductEvolutionV1._3.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;

        bool isActive;

        #region Properties

        public IParser<T> Parser
        {
            get { return parser; }
            set { parser = value; }
        }

        public IParserSettings ParserSettings
        {
            get { return parserSettings; }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }

        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        #endregion



        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) 
            : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        private void Worker()
        {
            if(!isActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }
            var source = loader.GetSourceByItem();
            var result = parser.Parse(source);

            

            OnNewData?.Invoke(this, result);
            OnCompleted?.Invoke(this);
            isActive = false;

        }
    }
}
