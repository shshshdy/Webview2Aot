using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Diagnostics;


namespace Diga.WebView2.Wrapper
{
    //internal static class EventHandlerList
    //{
    //    private static readonly ConcurrentDictionary<string, DOMObject> EventObject;

    //    static EventHandlerList()
    //    {
    //        LockObject = new object();
    //        EventObject = new ConcurrentDictionary<string, DOMObject>();
    //    }

    //    public static bool TryAdd(string key, DOMObject obj)
    //    {
    //        if (EventObject.ContainsKey(key)) return false;
    //        return EventObject.TryAdd(key, obj);
    //    }

    //    public static DOMObject FindObject(string key)
    //    {
    //        if (key == null) return null;

    //        if (EventObject.TryGetValue(key, out DOMObject obj))
    //        {
    //            return obj;
    //        }

    //        return null;
    //    }

    //    public static void RaiseEvent(RpcEventHandlerArgs e)
    //    {

    //        DOMObject obj = FindObject(e.RpcObject.varname);
    //        obj?.RaiseEvent(e);

    //    }

    //    private static readonly object LockObject;
    //    internal static void RemoveByObject(DOMObject domObj)
    //    {
    //        var idList = new List<string>();
    //        lock (LockObject)
    //        {
    //            var obj = EventObject.ToArray();
    //            foreach (var item in obj)
    //            {
    //                if (item.Value == domObj)
    //                {
    //                    idList.Add(item.Key);
    //                }

    //            }

    //            foreach (string key in idList)
    //            {
    //                EventObject.TryRemove(key, out _);

    //            }
    //        }
    //    }
    //}

    public class RpcEventHandlerArgs : EventArgs
    {
        public IRpcObject RpcObject { get; }
        public string EventName { get; }
        public string ObjectId { get; }

        public RpcEventHandlerArgs(string id, string eventName, IRpcObject rpc)
        {
            this.ObjectId = id;
            this.EventName = eventName;
            this.RpcObject = rpc;
        }
    }


   

    [Guid("EF53ABF2-4216-40D3-AB11-02D31EF37C49")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface IRpcHandler //:IDispatch 
    {
        [DispId(1)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object GetNewRpc();
        [DispId(2)]
        void UnloadDom();
        [DispId(3)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool ReleaseObject([MarshalAs(UnmanagedType.Interface)] object obj);
        [DispId(4)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool Handle([MarshalAs(UnmanagedType.LPWStr)] string id, [MarshalAs(UnmanagedType.LPWStr)] string eventName, [MarshalAs(UnmanagedType.Interface)] object obj);

    }

    [Guid("492AB1FF-FF27-4A23-93A8-540A4B9DAC37")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface IRpcObject
    {
        [return: MarshalAs(UnmanagedType.LPWStr)]
        string get_id();
        void set_id([MarshalAs(UnmanagedType.LPWStr)] string id);

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string get_objId();

        void set_objId([MarshalAs(UnmanagedType.LPWStr)] string id);

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string get_varname();

        void set_varname([MarshalAs(UnmanagedType.LPWStr)] string id);

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string get_action();

        void set_action([MarshalAs(UnmanagedType.LPWStr)] string id);

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string get_param();

        void set_param([MarshalAs(UnmanagedType.LPWStr)] string id);

        [return: MarshalAs(UnmanagedType.Interface)]
        object get_item();

        void set_item([MarshalAs(UnmanagedType.Interface)] object obj);

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string idFullName();

        [return: MarshalAs(UnmanagedType.LPWStr)]
        string idName();
        [return: MarshalAs(UnmanagedType.Interface)]
        object Clone();
    }



    [Guid("DFAFC87A-0EC3-4FBA-8249-D754A17D1DDE")]
    [GeneratedComClass]
    public partial class RpcObject : IRpcObject
    {



        [return: MarshalAs(UnmanagedType.Interface)]
        public object Clone()
        {
            RpcObject destitation = (RpcObject)this.MemberwiseClone();
            return destitation;
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string get_action()
        {
            return _action;
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string get_id()
        {
            return _id;
        }

        [return: MarshalAs(UnmanagedType.Interface)]
        public object get_item()
        {
            return _item;
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string get_objId()
        {
            return _objId;
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string get_param()
        {
            return _param;
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string get_varname()
        {
            return _varname;
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string idFullName()
        {
            return "window.diga._HEAP_" + this._id.Replace("-", "_");
        }

        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string idName()
        {
            return "_HEAP_" + this._id.Replace("-", "_");
        }

        public void set_action([MarshalAs(UnmanagedType.LPWStr)] string action)
        {
            _action = action;
        }

        public void set_id([MarshalAs(UnmanagedType.LPWStr)] string id)
        {
            _id = id;
        }

        public void set_item([MarshalAs(UnmanagedType.Interface)] object obj)
        {
            _item = obj;
        }

        public void set_objId([MarshalAs(UnmanagedType.LPWStr)] string id)
        {
            _objId = id;
        }

        public void set_param([MarshalAs(UnmanagedType.LPWStr)] string param)
        {
            _param = param;
        }

        public void set_varname([MarshalAs(UnmanagedType.LPWStr)] string varname)
        {
            _varname = varname;
        }

        private string _id;
        private string _objId;
        private string _varname;
        private string _action;
        private string _param;
        private object _item;

    }


    [Guid("331ED0C1-A10E-421A-8E6D-D995AD904C76")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [GeneratedComClass]
    public partial class RpcHandler:IRpcHandler
    {
        //public void GetTypeInfoCount(out int count)
        //{
        //    // Rückgabe der Anzahl der Typinformationen (z.B. 4 für die Demonstration)
        //    count = 4;
        //}

        //public void GetTypeInfo(int iTInfo, int lcid, out IntPtr info)
        //{
        //    // Simulierte Implementierung, wenn Typinformationen nicht unterstützt werden
        //    info = IntPtr.Zero;
        //    throw new NotImplementedException("Type information not implemented.");
        //}

        //public void GetIDsOfNames(ref Guid riid, nint rgszNames, int cNames, int lcid, nint rgDispId)
        //{
        //    var reservedString = new string[cNames];
        //    for (int i = 0; i < cNames; i++)
        //    {
        //        reservedString[i] = Marshal.PtrToStringBSTR(Marshal.ReadIntPtr(rgszNames, i * IntPtr.Size));
        //    }

        //    // Initialisierung von DispId-Array
        //    var rrDispId = new int[cNames];

        //    // Zuordnung von Dispatch-IDs (DispId) zu Methoden- oder Eigenschaftsnamen
        //    for (int i = 0; i < cNames; i++)
        //    {
        //        switch (reservedString[i])
        //        {
        //            case nameof(GetNewRpc):
        //                rrDispId[i] = 1;
        //                break;
        //            case nameof(UnloadDom):
        //                rrDispId[i] = 2;
        //                break;
        //            case nameof(ReleaseObject):
        //                rrDispId[i] = 3;
        //                break;
        //            case nameof(Handle):
        //                rrDispId[i] = 4;
        //                break;
        //            default:
        //                throw new COMException("Method not found", unchecked((int)0x80020006)); // DISP_E_UNKNOWNNAME
        //        }
        //    }

        //    // Kopieren von DispId-Array in Speicher
        //    Marshal.Copy(rrDispId, 0, rgDispId, cNames);

        //}

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Plattformkompatibilität überprüfen", Justification = "<Ausstehend>")]
        //public void Invoke(int dispIdMember, ref Guid riid, int lcid, ushort wFlags, ref Interop.DISPPARAMS pDispParams, out object pVarResult, ref Interop.EXCEPINFO pExcepInfo, out int puArgErr)
        //{
        //    // Initialisieren von Ausgabewerten
        //    pVarResult = null;
        //    puArgErr = 0;

        //    // Verarbeiten basierend auf Dispatch-ID
        //    try
        //    {
        //        switch (dispIdMember)
        //        {
        //            case 1: // GetNewRpc
        //                pVarResult = GetNewRpc();
        //                break;
        //            case 2: // UnloadDom
        //                UnloadDom();
        //                break;
        //            case 3: // ReleaseObject
        //                if (pDispParams.cArgs >= 1 && pDispParams.rgvarg != IntPtr.Zero)
        //                {
        //                    object obj = Marshal.GetObjectForNativeVariant(pDispParams.rgvarg);

        //                    pVarResult = ReleaseObject(obj);
        //                }
        //                break;
        //            case 4: // Handle
        //                if (pDispParams.cArgs >= 3 && pDispParams.rgvarg != IntPtr.Zero)
        //                {
        //                    object obj = Marshal.GetObjectForNativeVariant(pDispParams.rgvarg);
        //                    string eventName = Marshal.GetObjectForNativeVariant(pDispParams.rgvarg + IntPtr.Size).ToString();
        //                    string id = Marshal.GetObjectForNativeVariant(pDispParams.rgvarg + (2 * IntPtr.Size)).ToString();
        //                    pVarResult = Handle(id, eventName, obj);
        //                }
        //                break;
        //            default:
        //                throw new COMException("Unknown member.", unchecked((int)0x80020003)); // DISP_E_MEMBERNOTFOUND
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Fehlerhandling
        //        pExcepInfo = new Interop.EXCEPINFO
        //        {
        //            bstrDescription = ex.Message,
        //            scode = unchecked((int)0x80020009) // DISP_E_EXCEPTION
        //        };
        //        throw;
        //    }
        //}

        [return: MarshalAs(UnmanagedType.Interface)]
        public object GetNewRpc()
        {

            var rpc = new RpcObject();
            rpc.set_id(Guid.NewGuid().ToString());
            rpc.set_item(null);
            return rpc;

        }

        [return: MarshalAs(UnmanagedType.Bool)]
        public bool Handle([MarshalAs(UnmanagedType.LPWStr)] string id, [MarshalAs(UnmanagedType.LPWStr)] string eventName, [MarshalAs(UnmanagedType.Interface)] object obj)
        {
            IRpcObject o = (IRpcObject)obj;

            RpcEventHandlerArgs args = new RpcEventHandlerArgs(id, eventName, o);
            //EventHandlerList.RaiseEvent(args);
            OnRpcEvent(args);
            return true;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        public bool ReleaseObject([MarshalAs(UnmanagedType.Interface)] object obj)
        {
            IRpcObject rpc = (IRpcObject)obj;
            if (this.RpcList.ContainsKey(rpc.get_id()))
            {
                this.RpcList.Remove(rpc.get_id());
                return true;
            }
            return false;
        }

        public void UnloadDom()
        {
            try
            {

                RpcDomUnloadEvent?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        protected virtual void OnRpcEvent(RpcEventHandlerArgs e)
        {
            try
            {
                //this.Tasks.Enqueue(new Task(()=>{this.RpcEvent?.Invoke(this,e);}));
                this.RpcEvent?.Invoke(this, e);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);

            }

        }


        public event EventHandler<RpcEventHandlerArgs> RpcEvent;
        public event EventHandler RpcDomUnloadEvent;
        public Dictionary<string, object> RpcList = new Dictionary<string, object>();
    }


}
