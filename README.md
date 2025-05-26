# Virtual-Reality-Project (On-Going)
It's a personal project and also for my thesis for my bachelor's degree. So, the game is on VR about communication training in a presentation scenario.
There are 2 session, preparation session and training session. In preparation, users can explore the VR environment and try out the features contained in the application. In training session, users will be doing a presentation in front of virtual audiences (NPC). 

<h2>Features</h2>
There are 3 main features in this project:

<b>1. Speech Recognition</b>

In this project, I am using Automatic Speech Recognition model from Whisper and run in local using <a href="https://huggingface.co/unity/inference-engine-whisper-tiny">Unity Inference AI</a>. The AI model that I am using is Bahasa Indonesia by <a href="https://huggingface.co/cahya/whisper-medium-id">Cahya/Whisper-medium-id</a>. For the implementation, it based on <a href="https://www.patreon.com/posts/project-source-107788463">Ludic Worlds</a> and I did some modification for my project. This feature will count the words per minute, volume, and filler words.

<b>2. Eye Contact</b>

For eye contact, the user must look at the virtual audience for a few seconds. When fulfilled, the eye contact value will increase.

<b>3. Hand Movement</b>

Hand movement value is based on device controller movement with maximum value 100.

<h2>How To Use Speech Recognition</h2>
To Implement the speech recognition model:

1. Download all of the .onnx model from <a href="https://drive.google.com/drive/folders/1Pfht0hF1S8TaZ4XhocEWLq2CBLTIA3Y3?usp=sharing">here</a>.
2. Import the .onnx model to the project.
3. Drag the decoder_model.onnx to the decorder model field on RunWhisper.cs
4. Drag the encoder_model.onnx to the encoder model field on RunWhisper.cs
5. Drag the logMelSpectro.sentis to spectro model field on RunWhisper.cs
6. Drag the vocab.json to vocab field on RunWhisper.cs
7. Hold secondary button to start recording and release it to stop recording
8. Press primary button to transcibe and the text will appear in a few seconds.

<b>Nb: Because this is an on-going project, so there will be a lot of bug or problem. I am still trying to finish this project.</b>
