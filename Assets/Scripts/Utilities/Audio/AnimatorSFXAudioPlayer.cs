using UnityEngine;

namespace SotongStudio.Utilities.AudioSystem
{
    public class AnimatorSFXAudioPlayer : MonoBehaviour
    {
        public void PlaySFX(string sfxName)
        {
            BasicAudioSystem.Instance.PlaySFX(sfxName);
        }
    }
}
