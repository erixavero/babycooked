# Gameplay Footage
<table width="100%">
  <tbody>
    <tr>
      <td>
        <img alt="NurtureSpreeGIF1" src="https://github.com/user-attachments/assets/ced06c06-715b-4e23-957c-5de2a5d55a38">
      </td>
      <td>
        <img alt="NurtureSpreeGIF2" src="https://github.com/user-attachments/assets/7b0e5226-f585-4565-8b85-ed9f000e60cc">
      </td>
    </tr>
  </tbody>
</table>

---

# 👶 About
Nurture Spree is an 2D Top Down babysitting game. In Nurture Spree, players take the role of a daycare caregiver managing a constant flow of babies delivered by parents. Each baby arrives with specific needs — feeding, diaper changes, baths, or soothing — and it’s the player’s job to keep them healthy and happy before returning them. Using a baby monitor, players can anticipate needs and prepare in advance, but with multiple babies demanding attention at once, every second counts. By completing tasks, earning rewards, and upgrading their daycare with better tools, players must juggle chaos and strategy to run the ultimate nurturing spree.

---

# 📃 Main Script
<table width="100%">
  <thead>
    <tr>
      <th width="33%">
        <h4>
          <a>Script Name</a>
        </h4>
      </th>
      <th width="67%">
        <h4>
          <a>Script Description</a>
        </h4>
      </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        🎵 AudioManager.cs
      </td>
      <td>
        Responsible for everything sound related in the game.
      </td>
    </tr>
    <tr>
      <td>
        🧩 BabyCrib.cs
      </td>
      <td>
        Manages a Baby Crib behavior like generating needs.
      </td>
    </tr>
    <tr>
      <td>
        💬 Consumable.cs
      </td>
      <td>
        Handles how consumable work like the dragging and dropping on certain objects.
      </td>
    </tr>
    <tr>
      <td>
        💬 ConsumableBox.cs
      </td>
      <td>
        Handles consumable generation.
      </td>
    </tr>
    <tr>
      <td>
        💬 DataManager.cs
      </td>
      <td>
        Handles data saving and loading.
      </td>
    </tr>
    <tr>
      <td>
        💬 DoorHandler.cs
      </td>
      <td>
        Handles baby generation and sending baby off.
      </td>
    </tr>
    <tr>
      <td>
        💬 DraggableItem.cs
      </td>
      <td>
        Handles everything that can be dragged or grabbed.
      </td>
    </tr>
    <tr>
      <td>
        🔧 EvaluationHandler.cs
      </td>
      <td>
        Handles evalutaion of the current level.
      </td>
    </tr>
    <tr>
      <td>
        📖 LevelButtonHandler.cs
      </td>
      <td>
        Handles button UI and availability in level selection.
      </td>
    </tr>
    <tr>
      <td>
        🖼️ MenuHandler.cs
      </td>
      <td>
        Manages scene transition from main menu to the levels.
      </td>
    </tr>
    <tr>
      <td>
        💁 PauseButtonHandler.cs
      </td>
      <td>
        Handles pausing in game.
      </td>
    </tr>
    <tr>
      <td>
        SettingManager.cs
      </td>
      <td>
        Handles in game settings.
      </td>
    </tr>
    <tr>
      <td>
        💁 StationUIHandler.cs
      </td>
      <td>
        Handles Station Interactable (Showing Indicator) in Room.
      </td>
    </tr>
    <tr>
      <td>
        💁 Timer.cs
      </td>
      <td>
        Handles timer for each task to complete.
      </td>
    </tr>
    <tr>
      <td>
        💁 TutorialManager.cs
      </td>
      <td>
        Handles tutorial tab, showing previous or next tutorial in GIFs.
      </td>
    </tr>
  </tbody>
</table>

---

# 📃 Bathing Station Script
<table width="100%">
  <thead>
    <tr>
      <th width="33%">
        <h4>
          <a>Script Name</a>
        </h4>
      </th>
      <th width="67%">
        <h4>
          <a>Script Description</a>
        </h4>
      </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        🏠 BathingStation.cs
      </td>
      <td>
        Handles the opening and closing from a bathings station and the minigames.
      </td>
    </tr>
    <tr>
      <td>
        🧩 ScrubMinigame.cs
      </td>
      <td>
        Handles the scrubbing minigame logic.
      </td>
    </tr>
    <tr>
      <td>
        🧼 Scrubber.cs
      </td>
      <td>
        Handles how the scrubber reacts when interacting with the baby.
      </td>
    </tr>
    <tr>
      <td>
        🧴 Shampoo.cs
      </td>
      <td>
        Handles how the shampoo reacts when interacting with the baby.
      </td>
    </tr>
    <tr>
      <td>
        🫧 Soap.cs
      </td>
      <td>
        Handles how the soap reacts when interacting with the baby.
      </td>
    </tr>
    <tr>
      <td>
        🥶 TemperatureMinigame.cs
      </td>
      <td>
        Handles the temperature minigame logic.
      </td>
    </tr>
  </tbody>
</table>

---

# 🩲 Diaper Station Script
<table width="100%">
  <thead>
    <tr>
      <th width="33%">
        <h4>
          <a>Script Name</a>
        </h4>
      </th>
      <th width="67%">
        <h4>
          <a>Script Description</a>
        </h4>
      </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        👶 BabyToBeCleaned.cs
      </td>
      <td>
        Manages the condition of baby being cleaned.
      </td>
    </tr>
    <tr>
      <td>
        🧻 BabyWipes.cs
      </td>
      <td>
        Inherited from Consumable class, Manages Reaction from BabyWipes to BabyToBeCleaned.
      </td>
    </tr>
    <tr>
      <td>
        🩲 CleanDiaper.cs
      </td>
      <td>
        Inherited from Consumable class, Manages Reaction from CleanDiaper to BabyToBeCleaned.
      </td>
    </tr>
    <tr>
      <td>
        🏠 DiaperStation.cs
      </td>
      <td>
        Handles the opening and closing from a bathings station.
      </td>
    </tr>
    <tr>
      <td>
        🩲 DirtyDiaper.cs
      </td>
      <td>
        Inherited from Consumable class, Manages Reaction from BabyToBeCleaned to Trash (object).
      </td>
    </tr>
    <tr>
      <td>
        🧴 PowderPad.cs
      </td>
      <td>
        Inherited from Consumable class, Manages Reaction from powder pad to BabyToBeCleaned.
      </td>
    </tr>
  </tbody>
</table>

---

# 🐮 Milk Station Script
<table width="100%">
  <thead>
    <tr>
      <th width="33%">
        <h4>
          <a>Script Name</a>
        </h4>
      </th>
      <th width="67%">
        <h4>
          <a>Script Description</a>
        </h4>
      </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        ♨️ Kettle.cs
      </td>
      <td>
        Handles kettle interaction and animation calling.
      </td>
    </tr>
    <tr>
      <td>
        🍼 MilkBottle.cs
      </td>
      <td>
        Handles milk bottle interaction, like shaking and storing powder amount.
      </td>
    </tr>
    <tr>
      <td>
        🍼 MilkPowder.cs
      </td>
      <td>
        Inherited from Consumable class, Manages Reaction from CleanDiaper to BabyToBeCleaned.
      </td>
    </tr>
    <tr>
      <td>
        🏠 MilkStation.cs
      </td>
      <td>
        Handles the opening and closing from a bathings station.
      </td>
    </tr>
  </tbody>
</table>
