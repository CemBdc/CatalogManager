using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManager.Benchmark
{
    [RPlotExporter]
    [AsciiDocExporter]
    [CsvExporter]
    [HtmlExporter]
    public class BenchmarkRESTClient
    {
        [Params(100, 200)]
        public int IterationCount;

        readonly RESTClient restClient = new RESTClient();

        [Benchmark]
        public async Task RestGetPayloadAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await restClient.GetPayloadAsync();
            }
        }
    }

    public class AllowNonOptimized: ManualConfig
    {
        public AllowNonOptimized()
        {
            Add(JitOptimizationsValidator.DontFailOnError);

            Add(DefaultConfig.Instance.GetLoggers().ToArray());
            Add(DefaultConfig.Instance.GetExporters().ToArray());
            Add(DefaultConfig.Instance.GetColumnProviders().ToArray());
        }
    }
}
