namespace SevenStrikeModules.XTween
{
    using System;
    using UnityEngine;

    #region 预设类
    /// <summary>
    /// 动画预设数据基类
    /// </summary>
    [Serializable]
    public class XTweenPresetBase
    {
        public string Name;
        public string Description;
        public float Duration = 1f;
        public float Delay = 0f;
        public bool UseRandomDelay = false;
        public RandomDelay RandomDelay;
        public EaseMode EaseMode = EaseMode.InOutCubic;
        public bool UseCurve = false;
        public AnimationCurve Curve;
        public int LoopCount = 0;
        public float LoopDelay = 0f;
        public XTween_LoopType LoopType = XTween_LoopType.Restart;
        public bool IsRelative = false;
        public bool IsAutoKill = false;

        public void Set_PresetName(string name)
        {
            this.Name = name;
        }

        public void Set_Preset_Description(string des)
        {
            this.Description = des;
        }
    }

    /// <summary>
    /// Alpha动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Alpha : XTweenPresetBase
    {
        public float EndValue = 0f;
        public float FromValue = 0f;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Color动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Color : XTweenPresetBase
    {
        public Color EndValue = Color.white;
        public Color FromValue = Color.white;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Position动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Position : XTweenPresetBase
    {
        public XTweenTypes_Positions PositionType = XTweenTypes_Positions.锚点位置_AnchoredPosition;
        public Vector2 EndValue_Vector2 = Vector2.zero;
        public Vector3 EndValue_Vector3 = Vector3.zero;
        public Vector2 FromValue_Vector2 = Vector2.zero;
        public Vector3 FromValue_Vector3 = Vector3.zero;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Rotation动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Rotation : XTweenPresetBase
    {
        public XTweenTypes_Rotations RotationType = XTweenTypes_Rotations.欧拉角度_Euler;
        public Vector3 EndValue_Euler = Vector3.zero;
        public Quaternion EndValue_Quaternion = Quaternion.identity;
        public Vector3 FromValue_Euler = Vector3.zero;
        public Quaternion FromValue_Quaternion = Quaternion.identity;
        public XTweenSpace AnimateSpace = XTweenSpace.相对;
        public XTweenRotationMode RotationMode = XTweenRotationMode.Normal;
        public XTweenRotateLerpType RotateMode = XTweenRotateLerpType.SlerpUnclamped;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Scale动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Scale : XTweenPresetBase
    {
        public Vector3 EndValue = Vector3.one;
        public Vector3 FromValue = Vector3.one;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Size动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Size : XTweenPresetBase
    {
        public Vector2 EndValue = Vector2.zero;
        public Vector2 FromValue = Vector2.zero;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Shake动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Shake : XTweenPresetBase
    {
        public XTweenTypes_Shakes ShakeType = XTweenTypes_Shakes.位置_Position;
        public Vector3 Strength_Vector3 = Vector3.one;
        public Vector2 Strength_Vector2 = Vector2.one;
        public float Vibrato = 10f;
        public float Randomness = 90f;
        public bool FadeShake = true;
    }

    /// <summary>
    /// Text动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Text : XTweenPresetBase
    {
        public XTweenTypes_Text TextType = XTweenTypes_Text.文字尺寸_FontSize;
        public int EndValue_Int = 0;
        public float EndValue_Float = 0;
        public Color EndValue_Color = Color.white;
        public string EndValue_String = "";
        public int FromValue_Int = 0;
        public float FromValue_Float = 0;
        public Color FromValue_Color = Color.white;
        public string FromValue_String = "";
        public bool IsExtendedString = false;
        public string TextCursor = "_";
        public float CursorBlinkTime = 0.5f;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// TMP Text动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_TmpText : XTweenPresetBase
    {
        public XTweenTypes_TmpText TmpTextType = XTweenTypes_TmpText.文字尺寸_FontSize;
        public float EndValue_Float = 0;
        public Color EndValue_Color = Color.white;
        public string EndValue_String = "";
        public Vector4 EndValue_Vector4 = Vector4.zero;
        public float FromValue_Float = 0;
        public Color FromValue_Color = Color.white;
        public string FromValue_String = "";
        public Vector4 FromValue_Vector4 = Vector4.zero;
        public bool IsExtendedString = false;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Fill动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Fill : XTweenPresetBase
    {
        public float EndValue = 1f;
        public float FromValue = 0f;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Tiled动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Tiled : XTweenPresetBase
    {
        public float EndValue = 1f;
        public float FromValue = 0f;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// Path动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_Path : XTweenPresetBase
    {
        // Path预设需要特殊处理，因为路径点太复杂
        // 可以只保存路径名称，实际路径点由XTween_PathTool管理
        public string PathName = "";
    }

    /// <summary>
    /// To动画预设
    /// </summary>
    [Serializable]
    public class XTweenPreset_To : XTweenPresetBase
    {
        public XTweenTypes_To ToType = XTweenTypes_To.浮点数_Float;
        public int EndValue_Int = 0;
        public float EndValue_Float = 0;
        public string EndValue_String = "";
        public Vector2 EndValue_Vector2 = Vector2.zero;
        public Vector3 EndValue_Vector3 = Vector3.zero;
        public Vector4 EndValue_Vector4 = Vector4.zero;
        public Color EndValue_Color = Color.white;
        public int FromValue_Int = 0;
        public float FromValue_Float = 0;
        public string FromValue_String = "";
        public Vector2 FromValue_Vector2 = Vector2.zero;
        public Vector3 FromValue_Vector3 = Vector3.zero;
        public Vector4 FromValue_Vector4 = Vector4.zero;
        public Color FromValue_Color = Color.white;
        public bool IsExtendedString = false;
        public string TextCursor = "_";
        public float CursorBlinkTime = 0.5f;
        public bool UseFromMode = false;
    }

    /// <summary>
    /// 预设容器 - 用于序列化/反序列化
    /// </summary>
    [Serializable]
    public class XTweenPresetContainer
    {
        public string Version = "1.0";
        public string Type;  // 动画类型标识
        public string JsonData;  // 具体的预设数据JSON
    }
    #endregion

    public static class XTween_PresetManager
    {
        public static void preset_CheckDataJsonExist()
        {

        }
    }
}
