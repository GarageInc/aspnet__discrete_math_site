using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication.Service.auto_generating_mathtasks;

namespace WebApplication.Service
{
    public class DeterminantComplexity
    {

        public static object GenerateByLevel(int id, int level, bool isAutoGenerator = false)
        {
            object result = null;

            switch (id)
            {
                case 0:
                    {
                        result = UnambiguousCodingService.GetRandomOneZeroString(level);
                        break;
                    }
                case 1:
                    {
                        result = PrefixCodeService.CheckIsDecodedByCode(level);
                        break;
                    }
                case 2:
                    {
                        result = UnambiguousDecodingService.GetDecodingCodeAndCode(level);
                        break;
                    }
                case 3:
                    {
                        result = HaffmaneService.GetRandomNumbersString(level);
                        break;
                    }
                case 4:
                    {
                        var hemmingResult = HemmingService.Generate(level);

                        result = string.Join("", hemmingResult.code);
                        break;
                    }
                case 5:
                    {
                        result = BooleanFormulaService.GetRandomBooleanFormulaByLevel(id, level);
                        break;
                    }

            }
            return result;
        }
    }
}