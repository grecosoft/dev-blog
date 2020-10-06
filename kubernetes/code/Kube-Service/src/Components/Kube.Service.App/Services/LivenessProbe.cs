using Kube.Service.Domain;

namespace Kube.Service.App
{
    public class LivenessProbe : ILivenessProbe
    {
        private bool _isHealthy = true;
        
        public bool IsCurrentStateHealthy() => _isHealthy;

        public void ToggleState() => _isHealthy = !_isHealthy;
    }
}