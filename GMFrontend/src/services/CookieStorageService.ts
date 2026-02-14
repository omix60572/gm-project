class CookieStorageService {
  private static Instance: CookieStorageService | null = null;

  private constructor() { }
  public static getInstance(): CookieStorageService {
    CookieStorageService.Instance ??= new CookieStorageService();
    return CookieStorageService.Instance;
  }

  public async saveValue(key: string, value: string, expireHours: number): Promise<void> {
    try {
      const currentDate = new Date();
      await cookieStore.set({
        name: key,
        value: value,
        expires: currentDate.getTime() + (expireHours * 60 * 60 * 1000) // milliseconds (UTC)
      });
    } catch (error) {
      console.log(error);
    }
  }

  public async getValue(key: string): Promise<string | null> {
    try {
      const cookie = await cookieStore.get(key);
      if (cookie?.value !== null && cookie?.value !== undefined) {
        return cookie.value;
      }
    } catch (error) {
      console.log(error);
    }

    return null;
  }
}

export default CookieStorageService;
