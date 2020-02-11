
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; // for Marshal
using NewElectronicTechnology.SynView;


namespace WindowsFormsApp1
{
    public class CCamera
    {
        private const int NumberOfBuffers = 10;
        private LvSystem m_pSystem;
        private LvInterface m_pInterface;
        private LvDevice m_pDevice;
        private LvStream m_pStream;
        private LvRenderer m_pRenderer;
        private LvBuffer[] m_Buffers;
        private IntPtr m_hDisplayWnd;
        private LvEvent m_pEvent;

        //-----------------------------------------------------------------------------
        // CCamera constructor
        public CCamera()
        {
            m_pSystem = null;
            m_pInterface = null;
            m_pDevice = null;
            m_pStream = null;
            m_pRenderer = null;
            m_pEvent = null;
            m_Buffers = new LvBuffer[NumberOfBuffers];
            for (int i = 0; i < NumberOfBuffers; i++)
                m_Buffers[i] = null;

            m_hDisplayWnd = (IntPtr)0;
        }
        //-----------------------------------------------------------------------------

        public void OpenCamera(IntPtr hDisplayWnd, LvSystem pSystem)
        {
            try
            {
                if (m_pDevice != null) CloseCamera();

                m_pSystem = pSystem;
                m_hDisplayWnd = hDisplayWnd;

                LvInterface pInterface = null;
                LvDevice pDevice = null;
                pSystem.UpdateInterfaceList();

                pSystem.OpenInterface("GigE Interface", ref pInterface);

                pInterface.UpdateDeviceList();
                pInterface.OpenDevice("SVGTL:80-6C-BC-30-06-BA", ref pDevice, LvDeviceAccess.Control);

                // The #error line below is intentionally inserted to the code in case you
                // generate the code from streamable or all writable features.
                // #error Review the feature settings code and remove the unnecessary items!
                // Before removing this line from the code, go carefully through all the feature
                // settings below and leave there only those, which really need to be set.

                LvDeviceFtr Ftr_TriggerLength = 0;
                LvDeviceFtr Ftr_Strobe1Source = 0;
                LvDeviceFtr Ftr_Strobe1Output = 0;
                LvDeviceFtr Ftr_Strobe1Invert = 0;
                LvDeviceFtr Ftr_Strobe2Source = 0;
                LvDeviceFtr Ftr_Strobe2Output = 0;
                LvDeviceFtr Ftr_Strobe2Invert = 0;
                LvDeviceFtr Ftr_UserEepromDataSelector = 0;
                LvDeviceFtr Ftr_TransferRequestMode = 0;
                LvDeviceFtr Ftr_ExpTogEnable = 0;
                LvDeviceFtr Ftr_ExpTogExposureTime = 0;
                LvDeviceFtr Ftr_RoiTogEnable = 0;
                LvDeviceFtr Ftr_BccEnable = 0;

                // --- Image Format Control ---
                pDevice.SetEnum(LvDeviceFtr.RegionSelector, (UInt32)LvRegionSelector.Region0);
                pDevice.SetInt(LvDeviceFtr.Width, 3664);
                pDevice.SetInt(LvDeviceFtr.Height, 2748);
                pDevice.SetInt(LvDeviceFtr.OffsetX, 0);
                pDevice.SetInt(LvDeviceFtr.OffsetY, 0);
                pDevice.SetEnum(LvDeviceFtr.RegionSelector, (UInt32)LvRegionSelector.Region0);
                pDevice.SetEnum(LvDeviceFtr.PixelFormat, (UInt32)LvPixelFormat.BayerGR8);
                // --- Acquisition ---
                pDevice.SetEnum(LvDeviceFtr.AcquisitionMode, (UInt32)LvAcquisitionMode.Continuous);
                pDevice.SetInt(LvDeviceFtr.AcquisitionFrameCount, 8);
                pDevice.SetInt(LvDeviceFtr.AcquisitionBurstFrameCount, 4);
                pDevice.SetFloat(LvDeviceFtr.AcquisitionFrameRate, 0.000000);
                // --- Trigger ---
                pDevice.SetEnum(LvDeviceFtr.TriggerSelector, (UInt32)LvTriggerSelector.FrameStart);
                pDevice.SetEnum(LvDeviceFtr.TriggerMode, (UInt32)LvTriggerMode.On);
                pDevice.SetEnum(LvDeviceFtr.TriggerSource, (UInt32)LvTriggerSource.Software);
                pDevice.SetEnum(LvDeviceFtr.TriggerActivation, (UInt32)LvTriggerActivation.RisingEdge);
                pDevice.SetFloat(LvDeviceFtr.TriggerDelay, 0.000000);
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "TriggerLength", ref Ftr_TriggerLength);
                pDevice.SetFloat(Ftr_TriggerLength, 4.000000);
                pDevice.SetEnumStr(LvDeviceFtr.TriggerDivider, "SubsamplingOff");
                pDevice.SetEnum(LvDeviceFtr.TriggerSelector, (UInt32)LvTriggerSelector.FrameBurstStart);
                pDevice.SetEnum(LvDeviceFtr.TriggerMode, (UInt32)LvTriggerMode.Off);
                pDevice.SetEnum(LvDeviceFtr.TriggerSource, (UInt32)LvTriggerSource.Software);
                pDevice.SetEnum(LvDeviceFtr.TriggerActivation, (UInt32)LvTriggerActivation.RisingEdge);
                pDevice.SetFloat(LvDeviceFtr.TriggerDelay, 0.000000);
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "TriggerLength", ref Ftr_TriggerLength);
                pDevice.SetFloat(Ftr_TriggerLength, 4.000000);
                pDevice.SetEnum(LvDeviceFtr.TriggerSelector, (UInt32)LvTriggerSelector.FrameStart);
                // --- Strobe 1 ---
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "Strobe1Source", ref Ftr_Strobe1Source);
                pDevice.SetEnumStr(Ftr_Strobe1Source, "Trigger");
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "Strobe1Output", ref Ftr_Strobe1Output);
                pDevice.SetEnumStr(Ftr_Strobe1Output, "Pulse");
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "Strobe1Invert", ref Ftr_Strobe1Invert);
                pDevice.SetBool(Ftr_Strobe1Invert, false);
                // --- Strobe 2 ---
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "Strobe2Source", ref Ftr_Strobe2Source);
                pDevice.SetEnumStr(Ftr_Strobe2Source, "Exposure");
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "Strobe2Output", ref Ftr_Strobe2Output);
                pDevice.SetEnumStr(Ftr_Strobe2Output, "Static");
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "Strobe2Invert", ref Ftr_Strobe2Invert);
                pDevice.SetBool(Ftr_Strobe2Invert, true);
                // --- Exposure ---
                pDevice.SetEnum(LvDeviceFtr.ExposureMode, (UInt32)LvExposureMode.Timed);
                pDevice.SetFloat(LvDeviceFtr.ExposureTime, 41213.863281);
                pDevice.SetEnum(LvDeviceFtr.ExposureAuto, (UInt32)LvExposureAuto.Once);
                // --- Analog Control ---
                pDevice.SetEnum(LvDeviceFtr.GainSelector, (UInt32)LvGainSelector.AnalogAll);
                pDevice.SetFloat(LvDeviceFtr.Gain, 1.000000);
                pDevice.SetEnum(LvDeviceFtr.GainSelector, (UInt32)LvGainSelector.DigitalAll);
                pDevice.SetFloat(LvDeviceFtr.Gain, 1.000000);
                pDevice.SetEnumStr(LvDeviceFtr.GainSelector, "DigitalRed");
                pDevice.SetFloat(LvDeviceFtr.Gain, 1.000000);
                pDevice.SetEnumStr(LvDeviceFtr.GainSelector, "DigitalGreen");
                pDevice.SetFloat(LvDeviceFtr.Gain, 1.000000);
                pDevice.SetEnumStr(LvDeviceFtr.GainSelector, "DigitalBlue");
                pDevice.SetFloat(LvDeviceFtr.Gain, 1.000000);
                pDevice.SetEnumStr(LvDeviceFtr.GainSelector, "DigitalGreen2Corr");
                pDevice.SetFloat(LvDeviceFtr.Gain, 1.000000);
                pDevice.SetEnum(LvDeviceFtr.GainSelector, (UInt32)LvGainSelector.DigitalAll);
                pDevice.SetFloat(LvDeviceFtr.Gamma, 0.500000);
                // --- Network Interface ---
                pDevice.SetInt(LvDeviceFtr.GevInterfaceSelector, 0);
                pDevice.SetBool(LvDeviceFtr.GevCurrentIPConfigurationDHCP, true);
                pDevice.SetBool(LvDeviceFtr.GevCurrentIPConfigurationPersistentIP, false);
                pDevice.SetInt(LvDeviceFtr.GevInterfaceSelector, 0);
                // --- User Set Control ---
                pDevice.SetEnum(LvDeviceFtr.UserSetSelector, (UInt32)LvUserSetSelector.Default);
                // --- User Eeprom Data ---
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "UserEepromDataSelector", ref Ftr_UserEepromDataSelector);
                pDevice.SetInt(Ftr_UserEepromDataSelector, 0);
                // --- Transfer Request Control ---
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "TransferRequestMode", ref Ftr_TransferRequestMode);
                pDevice.SetBool(Ftr_TransferRequestMode, false);
                // --- Exposure Toggle ---
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "ExpTogEnable", ref Ftr_ExpTogEnable);
                pDevice.SetBool(Ftr_ExpTogEnable, false);
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "ExpTogExposureTime", ref Ftr_ExpTogExposureTime);
                pDevice.SetFloat(Ftr_ExpTogExposureTime, 100.000000);
                // --- ROI Toggle ---
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "RoiTogEnable", ref Ftr_RoiTogEnable);
                pDevice.SetBool(Ftr_RoiTogEnable, false);
                // --- BCC Control ---
                pDevice.GetFeatureByName(LvFtrGroup.DeviceRemote, "BccEnable", ref Ftr_BccEnable);
                pDevice.SetBool(Ftr_BccEnable, true);
                // --- GenTL Device Module ---
                pDevice.SetInt(LvDeviceFtr.StreamSelector, 0);

                pDevice.SetInt(LvDeviceFtr.GevSCPD, 24000);

                m_pInterface = pInterface;
                m_pDevice = pDevice;

                m_pDevice.OpenStream("", ref m_pStream);
                m_pStream.OpenEvent(LvEventType.NewBuffer, ref m_pEvent);
                for (int i = 0; i < NumberOfBuffers; i++)
                    m_pStream.OpenBuffer((IntPtr)0, 0, (IntPtr)0, 0, ref m_Buffers[i]);
                m_pStream.SetInt32(LvStreamFtr.LvPostponeQueueBuffers, 3);
                m_pStream.OpenRenderer(ref m_pRenderer);
                m_pRenderer.SetWindow(m_hDisplayWnd);
                m_pRenderer.SetEnum(LvRendererFtr.LvRenderType, (UInt32)LvRenderType.ScaleToFit);
                m_pEvent.OnEventNewBuffer += new LvEventNewBufferHandler(NewBufferEventHandler);
                m_pEvent.SetCallbackNewBuffer(true, (IntPtr)0);
                m_pEvent.StartThread();
            }
            catch (LvException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //-----------------------------------------------------------------------------
        // Starts acquisition

        public void StartAcquisition()
        {
            try
            {
                m_pStream.FlushQueue(LvQueueOperation.AllToInput);
                if (m_pDevice == null) return;
                m_pDevice.AcquisitionStart();

            }
            catch (LvException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //-----------------------------------------------------------------------------
        // Stops acquisition

        public void StopAcquisition()
        {
            try
            {
                if (m_pStream == null) return;
                m_pDevice.AcquisitionStop();
            }
            catch (LvException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //-----------------------------------------------------------------------------
        // Closes the cameras

        public void CloseCamera()
        {
            try
            {
                if (m_pDevice == null) return;
                if (IsAcquiring()) StopAcquisition();
                m_pEvent.StopThread();
                m_pEvent.SetCallbackNewBuffer(false, (IntPtr)0);
                m_pStream.CloseEvent(ref m_pEvent);
                m_pStream.CloseRenderer(ref m_pRenderer);
                m_pStream.FlushQueue(LvQueueOperation.AllDiscard);
                for (int i = 0; i < NumberOfBuffers; i++)
                    if (m_Buffers[i] != null)
                        m_pStream.CloseBuffer(ref m_Buffers[i]);
                m_pDevice.CloseStream(ref m_pStream);
                m_pInterface.CloseDevice(ref m_pDevice);
                m_pSystem.CloseInterface(ref m_pInterface);
            }
            catch (LvException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //-----------------------------------------------------------------------------
        // Utility function for enabling/disabling buttons

        public bool IsOpen()
        {
            return m_pDevice != null;
        }

        //-----------------------------------------------------------------------------
        // Utility function for enabling/disabling buttons

        public bool IsAcquiring()
        {
            Boolean iIsAcquiring = false;
            try
            {
                if (m_pDevice == null) return false;
                m_pDevice.GetBool(LvDeviceFtr.LvDeviceIsAcquiring, ref iIsAcquiring);
            }
            catch (LvException)
            {
                // no message
            }
            return iIsAcquiring;
        }

        //-----------------------------------------------------------------------------

        public void Repaint()
        {
            try
            {
                if (m_pRenderer != null)
                    m_pRenderer.Repaint();
            }
            catch (LvException)
            {
                // no message
            }
        }

        //-----------------------------------------------------------------------------

        void NewBufferEventHandler(System.Object sender, LvNewBufferEventArgs e)
        {
            try
            {
                if (e.Buffer == null) return;

                // no image processing demonstrated - switch it ON in the code generation Wizard if you need it

                m_pRenderer.DisplayImage(e.Buffer);
                e.Buffer.Queue();
            }
            catch (LvException)
            {
                // no message
            }
        }

        public void Triggr()
        {
            m_pDevice.CmdExecute(LvDeviceFtr.TriggerSoftware);

        }
        



        //-----------------------------------------------------------------------------


    }
}
