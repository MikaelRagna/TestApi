using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PrototipoProjetoFinal.Data;

public class PesquisaDatabaseSettings
{
    public string ConnectionString { get; set; }

    public string Database { get; set; }

    public string PesquisaCollection { get; set; }
}
