class StringUtils {
  public static isEmpty(sourceString: string | null | undefined): boolean {
    return sourceString === null || sourceString === undefined || sourceString.length === 0;
  }

  public static defaultIfEmpty(sourceString: string | null | undefined, defaultValue: string): string {
    if (sourceString !== null && sourceString !== undefined && sourceString.length > 0){
      return sourceString;
    }

    return defaultValue;
  }
}

export default StringUtils;
