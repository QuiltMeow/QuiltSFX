using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace QuiltSFX
{
    public static class SystemSound
    {
        public static void playSystemSound(string path)
        {
            bool found = false;
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"AppEvents\Schemes\Apps\.Default\{path}\.Current"))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(null);
                        if (value != null)
                        {
                            SoundPlayer sound = new SoundPlayer((string)value);
                            sound.Play();
                            found = true;
                        }
                    }
                }
            }
            catch
            {
            }

            if (!found)
            {
                SystemSounds.Beep.Play(); 
            }
        }
    }
}