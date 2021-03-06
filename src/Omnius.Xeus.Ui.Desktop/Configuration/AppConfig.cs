using System;
using System.Threading.Tasks;
using Omnius.Core.Utils;
using Omnius.Xeus.Utils;

namespace Omnius.Xeus.Ui.Desktop.Configuration
{
    public class AppConfig
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public string? DaemonAddress { get; init; }

        public static async ValueTask<AppConfig?> LoadAsync(string configPath)
        {
            try
            {
                return YamlHelper.ReadFile<AppConfig>(configPath);
            }
            catch (Exception e)
            {
                _logger.Debug(e);
                return null;
            }
        }

        public async ValueTask SaveAsync(string configPath)
        {
            YamlHelper.WriteFile(configPath, this);
        }
    }
}
