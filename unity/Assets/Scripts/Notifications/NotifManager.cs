using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Notifications.Android;

public class NotifManager : MonoBehaviour
{

	
	public void SendTestNotif()
	{
		string notif_Title = "The kingdom needs you!";

		string notif_Message = "Fairies are running amok the land.";

		DateTime firetime = DateTime.Now.AddSeconds(5);

		AndroidNotification notif = new AndroidNotification(notif_Title, notif_Message, firetime);

		AndroidNotificationCenter.SendNotification(notif, "default");
	}

	private void SetupDefaultChannel()
	{
		//unique id to each channel
		string channel_ID = "default";

		//name of channel, will show up in notif settings
		string channel_title = "Default Channel";

		//importance of channel
		Importance importance = Importance.Default;

		//description of channel
		string description = "Default channel for this game";

		AndroidNotificationChannel defaultChannel =
			new AndroidNotificationChannel(channel_ID, channel_title, description, importance);

		AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);
	}

	private void Awake()
	{
		DontDestroyOnLoad(this);
		SetupDefaultChannel();
		AndroidNotificationCenter.CancelAllNotifications();
	}
	private void OnApplicationQuit()
	{
		SendTestNotif();
		Debug.Log("Application ending after " + Time.time + " seconds");

	}

}
