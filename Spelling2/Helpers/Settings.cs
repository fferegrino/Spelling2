// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Spelling2.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string FavoritesKey = "favorites_key";
		private static readonly string FavoritesDefault = string.Empty;

		#endregion


		public static string Favorites
		{
			get
			{
				return AppSettings.GetValueOrDefault(FavoritesKey, FavoritesDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(FavoritesKey, value);
			}
		}

	}
}