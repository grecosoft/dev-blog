namespace Kube.Service.Domain 
{
    public interface ILivenessProbe
    {
        public bool IsCurrentStateHealthy();
        public void ToggleState();

    }
}