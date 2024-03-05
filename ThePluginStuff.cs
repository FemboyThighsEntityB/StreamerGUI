using BepInEx;
using System;
using UnityEngine;
using Photon.Pun;
using GorillaNetworking;
using System.ComponentModel.Design;

namespace StreamerGui
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class ThePluginStuff : BaseUnityPlugin
    {
        Rect WindowRect = new Rect(0f, 0f, Screen.width, Screen.height);
        bool ShowCode = true;
        bool ShowPlayers = true;
        bool showGuiPlease = true;
        public void OnGUI()
        {
            GUI.skin.box.fontSize = 15;
            GUI.skin.label.fontSize = 15;
            Color YourColor = GorillaTagger.Instance.offlineVRRig.playerColor;

            if (showGuiPlease)
            {
                GUI.backgroundColor = YourColor;
                WindowRect = GUILayout.Window(235235235, WindowRect, new GUI.WindowFunction(Window), "STREAMER GUI".ToUpper(),
                Array.Empty<GUILayoutOption>());
            }
        }
        public void Window(int WindowID)
        {
            // Hello, I am entity_B and I am going to be telling you though these comments what my code doees

            // now this is if your in a room
            if (PhotonNetwork.InRoom)
            {
                // this is how I do my free spaces thing, it was a bit confusing for me
                int maxCapacity = 10;
                int currentPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
                int freeSpots = maxCapacity - currentPlayers;

                // if you have show code set to true, then all of this will show
                if (ShowCode)
                {
                    // if its 10 players, it will show this text
                    if (PhotonNetwork.CurrentRoom.PlayerCount == 10)
                    {
                        GUILayout.Label($" Room Code: <color=GREEN>{PhotonNetwork.CurrentRoom.Name}</color>".ToUpper());
                        GUILayout.Label($" <color=RED>ROOM FULL</color>".ToUpper());
                    }
                    // if its more than 0 players, it will show this
                    if (PhotonNetwork.CurrentRoom.PlayerCount < 9)
                    {
                        GUILayout.Label($" Room Code: <color=GREEN>{PhotonNetwork.CurrentRoom.Name}</color>".ToUpper());
                        GUILayout.Label($" <color=RED>{PhotonNetwork.CurrentRoom.PlayerCount}</color>/<color=RED>{PhotonNetwork.CurrentRoom.MaxPlayers}</color> Players".ToUpper());
                        GUILayout.Label($" <color=GREEN>There are {freeSpots} Empty Spaces</color>".ToUpper());
                    }
                    // if its 9 players, it will say there is 1 empty space, isntead of Spaces
                    else if (PhotonNetwork.CurrentRoom.PlayerCount == 9)
                    {
                        GUILayout.Label($" Room Code: <color=GREEN>{PhotonNetwork.CurrentRoom.Name}</color>".ToUpper());
                        GUILayout.Label($" <color=RED>{PhotonNetwork.CurrentRoom.PlayerCount}</color>/<color=RED>{PhotonNetwork.CurrentRoom.MaxPlayers}</color> Players".ToUpper());
                        GUILayout.Label($" <color=GREEN>There is {freeSpots} Empty Space</color>".ToUpper());
                    }
                }
                // this is if you have Showing the code set to false
                if (!ShowCode)
                {
                    // all of this is the same as the one above
                    if (PhotonNetwork.CurrentRoom.PlayerCount == 10)
                    {
                        GUILayout.Label($" Room Code: <color=RED>HIDDEN</color>".ToUpper());
                        GUILayout.Label($" <color=RED>ROOM FULL</color>".ToUpper());
                    }
                    if (PhotonNetwork.CurrentRoom.PlayerCount < 9)
                    {
                        GUILayout.Label($" Room Code: <color=RED>HIDDEN</color>".ToUpper());
                        GUILayout.Label($" <color=RED>{PhotonNetwork.CurrentRoom.PlayerCount}</color>/<color=RED>{PhotonNetwork.CurrentRoom.MaxPlayers}</color> Players".ToUpper());
                        GUILayout.Label($" <color=GREEN>There are {freeSpots} Empty Spaces</color>".ToUpper());
                    }
                    else if (PhotonNetwork.CurrentRoom.PlayerCount == 9)
                    {
                        GUILayout.Label($" Room Code: <color=RED>HIDDEN</color>".ToUpper());
                        GUILayout.Label($" <color=RED>{PhotonNetwork.CurrentRoom.PlayerCount}</color>/<color=RED>{PhotonNetwork.CurrentRoom.MaxPlayers}</color> Players".ToUpper());
                        GUILayout.Label($" <color=GREEN>There is {freeSpots} Empty Space</color>".ToUpper());
                    }
                }
                // this will show what gamemode your in, without saying "modded" ur queue, or the gamemode twice, Im sure there is a more simple way then what I done, but Idk what it is, so my apologies
                GUILayout.Label($" Gamemode: <color=GREEN>{GorillaComputer.instance.currentGameMode.ToString().Replace("MODDED_", "").Replace("DEFAULT", "").Replace("COMPETITIVE", "").Replace("MINIGAMES", "").Replace("CASUALCASUAL", "CASUAL").Replace("INFECTIONINFECTION", "INFECTION").Replace("HUNTHUNT", "HUNT").Replace("BATTLEPAINTBRAWL", "PAINTBRAWL")}</color>".ToUpper());
                // this is just some credit as I spent alot of time making this, and then eventually remade it, and its just small text in the botton corner
                // checking if ur in a pub
                if (PhotonNetwork.CurrentRoom.IsVisible == false)
                {
                    GUILayout.Label("<color=RED> IN A PRIVATE</color>");
                }
                else
                {
                    //shows ur map
                    GUILayout.Label($" IN MAP: <color=RED>{CurrentMap}</color>".ToUpper());
                }
                
                // this shows ur username
                GUILayout.Label($" STREAMERS USER: <color=GREEN>{PhotonNetwork.NickName}</color>");
                // this is for the players
                if (ShowPlayers)
                {
                    GUILayout.BeginVertical();
                    GUILayout.FlexibleSpace();
                    GUI.skin.label.fontSize = 15;
                    GUILayout.Label("<color=RED>PLAYER LIST</color>".ToUpper());
                    GUI.skin.label.fontSize = 12;
                    GUILayout.FlexibleSpace();
                    GUILayout.EndVertical();

                    foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                    {
                        GUILayout.Label($" <color=GREEN>{player.NickName}</color>".ToUpper());
                    }
                }
                GUI.skin.label.fontSize = 12;
                // just credit
                GUILayout.Label(" <color=RED>made by: Entity_B</color>".ToUpper());
            }
            else
            {
                // and this is if your NOT in a lobby
                // this gets your color code
                Color YourColor = GorillaTagger.Instance.offlineVRRig.playerColor;
                // seting it as your color
                GUI.backgroundColor = YourColor;
                // this is just making the text centered
                GUILayout.BeginVertical();
                GUILayout.FlexibleSpace();
                GUI.skin.label.fontSize = 15;
                GUILayout.Label($"<color=RED>Not In Room Right Now!</color>".ToUpper(), GUILayout.ExpandHeight(false));
                GUILayout.Space(7);

                GUILayout.Label("\n\n\n\n\n\nYou can drag this window around btw".ToUpper(), GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(false));
                GUILayout.FlexibleSpace();
                GUILayout.EndVertical();

                // heres how you hide your code
                // making it 2x2
                GUILayout.BeginHorizontal();
                if (GUILayout.Button($"SHOW CODE: {ShowCode}".ToUpper()))
                {
                    ShowCode = !ShowCode;
                }
                // this is incase if you wanna hide the player list
                if (GUILayout.Button($"SHOW PLAYERLIST: {ShowPlayers}".ToUpper()))
                {
                    ShowPlayers = !ShowPlayers;
                }
                // ending 2x2
                GUILayout.EndHorizontal();
                // and some more credit
                GUI.skin.label.fontSize = 12;
                GUILayout.Label("<color=RED> made by: Entity_B</color>".ToUpper());
            }
        }
        public void Update()
        {
            if (WindowRect != new Rect(0f, 0f, 400f, 200f))
            {
                WindowRect = new Rect(0f, 0f, 400f, 200f);
            }

            Event e = Event.current;
            if (e.isKey && e.keyCode == KeyCode.Slash)
            {
                // if you show click "/" it hides the GUI
                showGuiPlease = !showGuiPlease;
            }
        }
        // this was the only way I knew how to get the map, my apologies
        public static string CurrentMap
        {
            get
            {
                object obj;
                PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("gameMode", out obj);
                bool flag = obj.ToString().Contains("forest");
                string result;
                if (flag)
                {
                    result = "forest";
                }
                else
                {
                    bool flag2 = obj.ToString().Contains("city");
                    if (flag2)
                    {
                        result = "city";
                    }
                    else
                    {
                        bool flag3 = obj.ToString().Contains("canyon");
                        if (flag3)
                        {
                            result = "canyon";
                        }
                        else
                        {
                            bool flag4 = obj.ToString().Contains("cave");
                            if (flag4)
                            {
                                result = "cave";
                            }
                            else
                            {
                                bool flag5 = obj.ToString().Contains("beach");
                                if (flag5)
                                {
                                    result = "beach";
                                }
                                else
                                {
                                    bool flag6 = obj.ToString().Contains("mountain");
                                    if (flag6)
                                    {
                                        result = "mountain";
                                    }
                                    else
                                    {
                                        bool flag7 = obj.ToString().Contains("basement");
                                        if (flag7)
                                        {
                                            result = "basement";
                                        }
                                        else
                                        {
                                            bool flag8 = obj.ToString().Contains("clouds");
                                            if (flag8)
                                            {
                                                result = "clouds";
                                            }
                                            else
                                            {
                                                bool flag9 = obj.ToString().Contains("rotating");
                                                if (flag9)
                                                {
                                                    result = "rotating";
                                                }
                                                else
                                                {
                                                    bool flag10 = obj.ToString().Contains("private");
                                                    if (flag10)
                                                    {
                                                        result = "private";
                                                    }
                                                    else
                                                    {
                                                        result = null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return result;
            }
        }
    }
}
