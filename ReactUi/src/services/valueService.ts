export const casingToRender = (arr: string[] | string) => {
  if (typeof arr === "string") {
    let result = "";

    arr.split("").forEach((c, cIndex) => {
      if (cIndex !== 0 && c === c.toLocaleUpperCase()) {
        result += ` ${c}`;
      } else {
        result += c;
      }
    });
    return result;
  }

  return arr.map(i => {
    let result = "";

    i.split("").forEach((c, cIndex) => {
      if (cIndex !== 0 && c === c.toUpperCase()) {
        result += ` ${c}`;
      } else {
        result += c;
      }
    });

    return result;
  });
};
