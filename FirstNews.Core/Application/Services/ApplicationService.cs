using System.Collections.Generic;
using System.Threading.Tasks;
using FirstNews.Core.Application.Features;
using FirstNews.Core.Authorization;
using FirstNews.Core.Runtime.Session;

namespace FirstNews.Core.Application.Services
{
    // This class can be used as a base class for application services. 
    public abstract class ApplicationService : FirstNewsServiceBase, IApplicationService, IAvoidDuplicateCrossCuttingConcerns
    {
        public static string[] CommonPostfixes = { "AppService", "ApplicationService" };

        // Gets current session information.
        public ISession Session { get; set; }
        
        // Reference to the permission manager.
        public IPermissionManager PermissionManager { protected get; set; }

        // Reference to the permission checker.
        public IPermissionChecker PermissionChecker { protected get; set; }

        // Reference to the feature manager.
        public IFeatureManager FeatureManager { protected get; set; }

        // Reference to the feature checker.
        public IFeatureChecker FeatureChecker { protected get; set; }

        // Gets the applied cross cutting concerns.
        public List<string> AppliedCrossCuttingConcerns { get; } = new List<string>();

        protected ApplicationService()
        {
            Session = NullSession.Instance;
            PermissionChecker = NullPermissionChecker.Instance;
        }

        // Checks if current user is granted for a permission.
        protected virtual Task<bool> IsGrantedAsync(string permissionName)
        {
            return PermissionChecker.IsGrantedAsync(permissionName);
        }

        // Checks if current user is granted for a permission.
        protected virtual bool IsGranted(string permissionName)
        {
            return PermissionChecker.IsGranted(permissionName);
        }

        // Checks if given feature is enabled for current tenant.
        protected virtual Task<bool> IsEnabledAsync(string featureName)
        {
            return FeatureChecker.IsEnabledAsync(featureName);
        }

        // Checks if given feature is enabled for current tenant.
        protected virtual bool IsEnabled(string featureName)
        {
            return FeatureChecker.IsEnabled(featureName);
        }
    }
}
