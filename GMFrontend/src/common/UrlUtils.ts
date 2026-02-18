class UrlUtils {
  public static getCurrentLocation(): string {
    return document.location.origin;
  }

  public static changeCurrentLocation(url: string) {
    document.location.href = url;
  }

  public static goBack() {
    globalThis.history.go(-1);
  }
}

export default UrlUtils;
