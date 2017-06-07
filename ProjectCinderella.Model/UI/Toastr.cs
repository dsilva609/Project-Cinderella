using System;
using System.Collections.Generic;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.Model.UI
{
	[Serializable]
	public class Toastr
	{
		public bool ShowNewestOnTop { get; set; }
		public bool ShowCloseButton { get; set; }
		public List<ToastMessage> ToastMessages { get; set; }

		public ToastMessage AddToastMessage(string title, string message, MessageTypeEnum toastType)
		{
			var toast = new ToastMessage()
			{
				Title = title,
				Message = message,
				ToastType = toastType
			};
			ToastMessages.Add(toast);
			return toast;
		}

		public Toastr()
		{
			ToastMessages = new List<ToastMessage>();
			ShowNewestOnTop = false;
			ShowCloseButton = false;
		}
	}

	[Serializable]
	public class ToastMessage
	{
		public string Title { get; set; }
		public string Message { get; set; }
		public MessageTypeEnum ToastType { get; set; }
		public bool IsSticky { get; set; }
	}
}