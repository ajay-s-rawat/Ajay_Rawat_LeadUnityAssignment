# Ajay Singh Rawat – Lead Unity Developer Assignment

This Unity project is a **no-code training scene editor** that enables runtime NPC management and real-time AI-driven conversations using the **Convai API**. Designed with modular architecture and best practices, the project is built for WebGL and deployable as a hosted experience.

---

## 🌐 Live Demo

👉 [http://ajayrawatnocodeconvai.netlify.app](http://ajayrawatnocodeconvai.netlify.app)

---

## ✨ Features

- 🧍 **Add Unlimited NPCs**  
  Spawn multiple AI characters dynamically using the “Add NPC” button.

- 🧠 **Persona Selector**  
  Choose from AI personas (CIA or AIRA) via a dropdown menu.

- 🗨️ **Proximity-Based Interaction**  
  Approach an NPC to trigger the chat UI automatically.

- 💬 **Chat Input System**  
  Press `Enter` to start chatting. NPCs respond with real-time **Convai** replies — both text and voice.

---

## 🧱 Architecture Overview

This project is built with modular, loosely coupled components adhering to SOLID principles.

### 🧩 Core Components

- **NPCManager.cs**  
  Singleton responsible for spawning and tracking NPCs. Works with selected `PersonaData`.

- **PersonaSelector.cs**  
  Dropdown UI that references a `PersonaRegistry` to supply persona data at runtime.

- **UIManager.cs**  
  Handles UI button interactions and bridges UI with manager logic.

- **ConvaiNPC.cs**  
  Attached to each NPC. Stores Convai character ID/name and triggers selection logic.

- **ConvaiGRPCWebAPI.cs** *(SDK)*  
  Manages all API communication with Convai (voice/text, session handling).

- **ConvaiChatUIHandler.cs** *(SDK)*  
  Controls the transcript/chat UI. Dynamically syncs with new NPCs on spawn.

- **PersonaData.cs** *(ScriptableObject)*  
  Contains character name, ID, and prefab reference for each persona.

- **PersonaRegistry.cs**  
  ScriptableObject list of all available personas (CIA, AIRA, etc.).

---

## 🔁 Patterns & Practices

- **Singleton Pattern** – for core managers (e.g., `NPCManager`, `ConvaiGRPCWebAPI`)
- **ScriptableObjects** – for persona definitions and registry
- **Loose Coupling** – interaction between UI, data, and logic is modular
- **Single Responsibility** – each script handles only one concern
- **Extendable** – adding new NPCs is as easy as creating a new `PersonaData` asset

---

## 🛠️ Build & Hosting

- 🎯 **Platform**: WebGL
- ⚙️ **Scripting Backend**: Mono (required by Convai SDK)
- 🧪 **Optimization**:
  - Gzip compression enabled
  - Code stripping & unused assets removed
- 🚀 **Hosting**: Deployed via [Netlify](https://netlify.com)  
  [http://ajayrawatnocodeconvai.netlify.app](http://ajayrawatnocodeconvai.netlify.app)

---

## 📁 Project Structure

/
├── Project/ # Unity project (Assets/, Packages/, etc.)
├── Build/WebGL/ # WebGL build output (index.html, data, etc.)
├── README.md # Project overview (this file)
└── LICENSES.txt # Attributions for third-party assets


---

## 🧪 Challenges

- **Convai SDK WebGL Limitations**: Microphone input not supported in WebGL; text-only chat tested.
- **FBX Rig Compatibility**: Provided models required humanoid reconfiguration for Unity.
- **GitHub Push Errors**: WebGL build size exceeded 100MB file limit — resolved via Git LFS.

---

## 🚀 Next Steps

If extended beyond this MVP:
- Add **Undo/Redo** functionality using Command pattern
- Implement **drag-and-drop NPC placement**
- Persist scene layout using **JSON** or **ScriptableObject serialization**
- Support multiple concurrent AI chat sessions

---

## 📜 Licenses

See [`LICENSES.txt`](./LICENSES.txt) for all third-party attributions, including:
- Convai SDK
- 3D character models (CIA, AIRA)

---

## 🙋 Author

**Ajay Singh Rawat**  
Senior Unity Developer  
📧 ajayrawat222@gmail.com  
🌐 [ajayrawatnocodeconvai.netlify.app](http://ajayrawatnocodeconvai.netlify.app)

---

