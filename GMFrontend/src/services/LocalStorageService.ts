class LocalStorageService {
  private static Instance: LocalStorageService | null = null;

  private constructor() {}
  public static getInstance(): LocalStorageService {
    LocalStorageService.Instance ??= new LocalStorageService();
    return LocalStorageService.Instance;
  }

  public saveValue(key: string, value: any) {
    try {
      localStorage.setItem(key, value);
    } catch (error) {
      console.error(`Failed to save value to localStorage with key ${key} and value ${value}`, error);
    }
  }

  public getValue(key: string): string | null {
    try {
      return localStorage.getItem(key);
    } catch (error) {
      console.error(`Failed to get saved value from localStorage with key: ${key}`, error);
    }

    return null;
  }

  public clearValue(key: string) {
    try {
      localStorage.removeItem(key);
    } catch (error) {
      console.error(`Failed to clear value in localStorage with key: ${key}`, error);
    }
  }
}

export default LocalStorageService;
