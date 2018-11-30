import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "../redux/reduxStore/IState";

import AdministrationScreenComponent from "../screens/AdministrationScreenComponent";

const mapStateToProps = (state: IReduxState) => ({});

const mapDispatchToProps = (dispatch: Dispatch) => ({});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(AdministrationScreenComponent);
