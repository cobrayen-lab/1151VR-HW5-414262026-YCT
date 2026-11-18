### GitHub 連結 : https://github.com/cobrayen-lab/1151VR-HW5-414262026-YCT
### YouTube 連結 : [https://youtube.com/shorts/XmCKdz5FcEY?feature=share](https://youtu.be/YCyxvmIKEUE)
### 製作流程 :
1. ***建立 3D 場景***
    - 建立 Unity 3D 專案。
    - 使用 Terrain 製作草地與地形起伏。
    - 放置樹木(匯入模型)、草叢與背景山脈。<img width="85" height="88" alt="螢幕擷取畫面 2026-11-18 093842" src="https://github.com/user-attachments/assets/51e8e847-afec-4ceb-9d9f-ab72280f49bc" />

    - 調整 Camera 與 Directional Light。

2. ***匯入角色模型***
    - 匯入訓練家模型。<img width="46" height="113" alt="螢幕擷取畫面 2026-11-18 093559" src="https://github.com/user-attachments/assets/9e254e35-1b69-45da-8d76-635b397c6d78" />

    - 匯入寶可夢與精靈球模型。<img width="108" height="107" alt="螢幕擷取畫面 2026-11-18 093500" src="https://github.com/user-attachments/assets/7f137c2e-4b1f-4df7-bbb0-2d4492bd8e15" />
      <img width="65" height="66" alt="螢幕擷取畫面 2026-11-18 094456" src="https://github.com/user-attachments/assets/6555484b-11c9-4ea7-bd4d-84717540aa1e" />

    - 設定模型 Texture 與 Material。
    - 設定角色 Rig，確認骨架與動畫正常運作。

3. ***設定 Animator***
    - 建立 `TrainerAnimator`。
    - 建立 Idle 與 Throw 動畫狀態。
    - 新增 Trigger 參數 `Throw`。
    - 設定 Idle → Throw → Idle 的動畫切換。
    - 使用 C# 偵測 Space 鍵並觸發動畫。

4. ***建立精靈球 Prefab***
    - 建立精靈球物件。
    - 加入 Rigidbody 與 Collider。
    - 將物件儲存成 `PokeBall` Prefab。
    - 在右手骨骼下建立 `BallSpawnPoint`。

5. ***設定投擲動畫事件***
    - 在 Throw 動畫中新增 Animation Event。
    - 在放球時機呼叫 `ReleaseBall()`。
    - 生成精靈球並設定初速度。
    - 動畫結束時呼叫 `FinishThrow()`。

6. ***設定寶可夢命中點***
    - 為寶可夢加入 Collider。
    - 設定 `Pokemon` Tag。
    - 在寶可夢身體中央建立 `CaptureTarget`。
    - 使用 CaptureTarget 作為精靈球的飛行目標。

7. ***建立收服特效***
    - 建立 Particle System。
    - 設定粒子顏色、大小、速度與生命週期。
    - 儲存為 `CaptureEffect` Prefab。
    - 在精靈球碰撞時生成粒子特效。
    - 命中後移除寶可夢與精靈球。
### 相關操作 :
| 按鍵 | 功能 |
|---|---|
| Space | 訓練家執行 Throw 動畫並投擲精靈球 |

##### 遊戲操作流程：

  1. 執行 Unity 場景。
  2. 按下 `Space`。
  3. 訓練家執行 Throw 動畫。
  4. 精靈球從右手飛出。
  5. 精靈球沿拋物線飛向寶可夢。
  6. 命中後產生收服特效。
  7. 寶可夢消失，完成收服。

### 開發過程遇到的問題與解決方式

| 問題 | 解決方式 |
|---|---|
| 無法播放 Throw 動畫 | 檢查 Rig、Animator Controller 與 Trigger |
| 精靈球生成後不會移動 | 檢查 Rigidbody 與 linearVelocity |
| 精靈球無法命中寶可夢 | 使用拋物線公式計算初速度 |
| 寶可夢原始座標不正確 | 新增 CaptureTarget 指定命中位置 |
| 命中後沒有粒子特效 | 檢查 CaptureEffect Prefab 與 Particle System |
| 粒子生成但無法看見 | 調整 Start Size、Emission 與 Renderer |
| 特效在錯誤的位置播放 | 將生成位置改成 CaptureTarget.position |
| 遊戲開始時就播放特效 | 移除場景中預先放置的 CaptureEffect |
