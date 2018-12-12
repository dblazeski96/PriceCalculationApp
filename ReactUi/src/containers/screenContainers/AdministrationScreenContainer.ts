import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "src/redux/store/IReduxState";

import AdministrationScreenComponent from "src/screens/AdministrationScreenComponent";

const mapStateToProps = (state: IReduxState) => ({});

const mapDispatchToProps = (dispatch: Dispatch) => ({});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(AdministrationScreenComponent);
