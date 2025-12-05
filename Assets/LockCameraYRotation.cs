using Unity.Cinemachine;
using UnityEngine;

// Virtual Cameraにアタッチする拡張スクリプト
public class LockCameraYRotation : CinemachineExtension
{
    [Tooltip("固定したいY軸の回転角度")]
    public float m_ZRotation = 0f; // 例: 常に正面向き

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage,
        ref CameraState state,
        float deltaTime)
    {
        // Aim Stageの後に実行
        if (stage == CinemachineCore.Stage.Aim)
        {
            // 現在の回転を取得
            Quaternion rot = state.RawOrientation;

            // Y軸回転を上書き
            rot = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, m_ZRotation);

            // カメラの状態に適用
            state.RawOrientation = rot;
        }
    }
}