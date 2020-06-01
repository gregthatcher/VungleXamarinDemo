using System;
using System.Collections.Generic;
using System.Text;

namespace VungleXamarinDemo
{
    /// <summary>
    /// We use this interface for Dependency Injection of the Vungle SDK
    ///  For iOS and Android, the implementation of these methods should do nothing
    ///  Ideas came from: https://stackoverflow.com/questions/24251020/write-device-platform-specific-code-in-xamarin-forms
    /// </summary>
    public interface IVungleInterface
    {
        void InitializeVungle(String appID);
        void LoadAd(String placementID);
        void PlayAd(String placementID);

        event NotifyInitializedDelegate VungleInitializedEvent;
        event NotifyAdLoaded VungleAdLoadedEvent;
        event NotifyDiagnostic VungleDiagnosticEvent;
    }

    public delegate void NotifyInitializedDelegate(bool initialized, List<String> placements, String errorMessage);
    public delegate void NotifyAdLoaded(String placement, bool loaded);
    public delegate void NotifyDiagnostic(String message);


}
