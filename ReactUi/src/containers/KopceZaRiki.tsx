import * as React from "react";
import { connect } from "react-redux";
import { KopceZaRikiComponent } from "src/components/KopceZaRikiComponent";
import { IState } from "src/redux/reduxStore/IState";
import { Dispatch, AnyAction } from "redux";
import { showRikiText } from "src/redux/reduxActions/actions";

const mapStateToProps = (state: IState) => ({
  rikiText: state.testReducer.rikiText
});

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  handleKopceZaRikiClick: (event: React.MouseEvent<HTMLButtonElement>) => {
    dispatch(
      showRikiText(`
      ________  __                                  __  __                       __            __                  __                                                __ 
      |        \\|  \\                                |  \\|  \\                     |  \\          |  \\                |  \\                                              |  \\
       \\$$$$$$$$| $$____    ______          _______ | $$ \\$$  ______   _______  _| $$_          \\$$  _______       | $$____    ______    ______    ______   __    __ | $$
         | $$   | $$    \\  /      \\        /       \\| $$|  \\ /      \\ |       \\|   $$ \\        |  \\ /       \\      | $$    \\  |      \\  /      \\  /      \\ |  \\  |  \\| $$
         | $$   | $$$$$$$\\|  $$$$$$\\      |  $$$$$$$| $$| $$|  $$$$$$\\| $$$$$$$\\\\$$$$$$        | $$|  $$$$$$$      | $$$$$$$\\  \\$$$$$$\\|  $$$$$$\\|  $$$$$$\\| $$  | $$| $$
         | $$   | $$  | $$| $$    $$      | $$      | $$| $$| $$    $$| $$  | $$ | $$ __       | $$ \\$$    \\       | $$  | $$ /      $$| $$  | $$| $$  | $$| $$  | $$ \\$$
         | $$   | $$  | $$| $$$$$$$$      | $$_____ | $$| $$| $$$$$$$$| $$  | $$ | $$|  \\      | $$ _\\$$$$$$\\      | $$  | $$|  $$$$$$$| $$__/ $$| $$__/ $$| $$__/ $$ __ 
         | $$   | $$  | $$ \\$$     \\       \\$$     \\| $$| $$ \\$$     \\| $$  | $$  \\$$  $$      | $$|       $$      | $$  | $$ \\$$    $$| $$    $$| $$    $$ \\$$    $$|  \\
          \\$$    \\$$   \\$$  \\$$$$$$$        \\$$$$$$$ \\$$ \\$$  \\$$$$$$$ \\$$   \\$$   \\$$$$        \\$$ \\$$$$$$$        \\$$   \\$$  \\$$$$$$$| $$$$$$$ | $$$$$$$  _\\$$$$$$$ \\$$
                                                                                                                                       | $$      | $$      |  \\__| $$    
                                                                                                                                       | $$      | $$       \\$$    $$    
                                                                                                                                        \\$$       \\$$        \\$$$$$$     
    `)
    );
  }
});

export const KopceZaRiki = connect(
  mapStateToProps,
  mapDispatchToProps
)(KopceZaRikiComponent);
