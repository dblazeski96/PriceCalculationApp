import * as React from "react";

interface IProps {
  rikiText: string;

  handleKopceZaRikiClick: (event: React.MouseEvent<HTMLButtonElement>) => void;
}

export const KopceZaRikiComponent = ({
  rikiText,
  handleKopceZaRikiClick
}: IProps) => {
  return (
    <div
      style={{
        fontFamily: "Consolas",
        whiteSpace: "pre"
      }}
    >
      <button onClick={handleKopceZaRikiClick}>Kopce Za Riki</button>
      {rikiText}
    </div>
  );
};
