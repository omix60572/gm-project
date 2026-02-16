class JsonUtils {
  public static tryParseJsonString<T>(sourceString: string | null): T | null {
    if (sourceString !== null && sourceString !== undefined && sourceString.length > 0) {
      try {
        const result = JSON.parse(sourceString) as T;
        return result;
      } catch(error) {
        console.log(error);
      }
    }

    return null;
  }
}

export default JsonUtils;
