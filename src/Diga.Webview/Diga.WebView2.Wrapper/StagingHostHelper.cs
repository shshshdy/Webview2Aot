using Diga.WebView2.Interop;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;


namespace Diga.WebView2.Wrapper
{



    [GeneratedComClass]
    public partial  class StagingHostHelper : ICoreWebView2StagingHostObjectHelper
    {
        private static nint ConvertStringArrayToNint(string[] strings)
        {
            if (strings == null || strings.Length == 0)
            {
                return IntPtr.Zero;
            }

            // Speicherplatz für die Zeiger auf die Strings reservieren
            IntPtr arrayPtr = Marshal.AllocCoTaskMem(strings.Length * IntPtr.Size);

            for (int i = 0; i < strings.Length; i++)
            {
                // Konvertiere jeden String in einen BSTR
                IntPtr bstr = Marshal.StringToBSTR(strings[i]);

                // Schreibe den Zeiger auf das BSTR in das Array
                Marshal.WriteIntPtr(arrayPtr, i * IntPtr.Size, bstr);
            }

            return (nint)arrayPtr; // Rückgabe als nint
        }

        private static void FreeStringArrayNint(nint arrayPtr, int count)
        {
            if (arrayPtr == IntPtr.Zero)
            {
                return;
            }

            // Freigeben jedes BSTR im Array
            for (int i = 0; i < count; i++)
            {
                IntPtr bstr = Marshal.ReadIntPtr((IntPtr)arrayPtr, i * IntPtr.Size);
                Marshal.FreeBSTR(bstr);
            }

            // Speicher für das Array freigeben
            Marshal.FreeCoTaskMem((IntPtr)arrayPtr);
        }

        public int IsMethodMember([MarshalAs(UnmanagedType.Interface)] ref object rawObject, [MarshalAs(UnmanagedType.LPWStr)] string memberName)
        {
            try
            {


#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
                var dispatch = Marshal.GetIDispatchForObject(rawObject);
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
                var guid = Guid.Empty;
                var names = new[] { memberName };
                var dispIds = new int[1];
                int result = Marshal.QueryInterface(dispatch, in guid, out var ppv);
                nint strsPtr = ConvertStringArrayToNint(names);
                nint dispIdsPtr = Marshal.UnsafeAddrOfPinnedArrayElement(dispIds, 0);
                ((Interop.IDispatch)rawObject).GetIDsOfNames(ref guid, strsPtr, 1, 0, dispIdsPtr);

                FreeStringArrayNint(strsPtr, names.Length);
                return 1;
            }
            catch (COMException ex) when ((uint)ex.ErrorCode == 0x80020006)
            {

                return 0;
            }
        }
    }
}
