// Theme storage keys
const ThemeStorageKey = 'selectedTheme';
const DefaultTheme = 'dark';

// Theme types
export type AppColorTheme = 'light' | 'dark';

/**
 * LocalStorageService handles saving and retrieving data from localStorage
 */
class LocalStorageService {
  /**
   * Saves selected theme to localStorage
   * @param theme AppColorTheme - Theme to save ('light' or 'dark')
   */
  saveTheme(theme: AppColorTheme): void {
    try {
      localStorage.setItem(ThemeStorageKey, theme);
    } catch (error) {
      console.error('Failed to save theme value to localStorage:', error);
    }
  }

  /**
   * Retrieves saved theme from localStorage
   * @returns AppColorTheme - The saved theme ('light' or 'dark') or default theme if not found
   */
  getTheme(): AppColorTheme {
    try {
      const savedTheme = localStorage.getItem(ThemeStorageKey);
      return (savedTheme === 'light' || savedTheme === 'dark') ? savedTheme : DefaultTheme;
    } catch (error) {
      console.error('Failed to get theme value from localStorage:', error);
      return DefaultTheme;
    }
  }

  /**
   * Clears saved theme in localStorage
   */
  clearTheme(): void {
    try {
      localStorage.removeItem(ThemeStorageKey);
    } catch (error) {
      console.error('Failed to clear theme value in localStorage:', error);
    }
  }
}

// Export singleton instance
export const localStorageService = new LocalStorageService();
export default LocalStorageService;
