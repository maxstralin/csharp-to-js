//CSharpToJs: auto
import ComplexType from './Subfolder/ComplexType.js';
class Model {
	constructor() {
		this.boolProp = true;
		this.nullString = null;
		this.nulledComplexType = null;
		get complexType() => new ComplexType();
	}
}
export default Model;