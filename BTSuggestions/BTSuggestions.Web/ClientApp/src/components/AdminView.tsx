import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Button, Icon, Select, Input, InputNumber, Popconfirm, message } from 'antd';
import AdminViewEntity from '../entity/AdminViewEntity';
import { statusList } from '../types/dropdownValues/statusTypes';
import { painPointList } from '../types/dropdownValues/painPointTypes';
import { industryList } from '../types/dropdownValues/industryTypes';
import { SelectOption } from '../types/dropdownValues/SelectOption';
import '../styles/AdminView.css';
import TextArea from 'antd/lib/input/TextArea';
import { IPainPointHandler, PainPointHandler } from '../utilities/painPointHandler';
import PainPointEntity from '../entity/PainPointEntity';
import { isSequenceExpression } from '@babel/types';

const { Content } = Layout;

interface IAdminViewProps {
    data: AdminViewEntity;
    painPointHandler?: IPainPointHandler;
}

interface IAdminViewState {
    issues: PainPointEntity[];
    isFetching: boolean;
}
interface IColumnViewProps {
    data: PainPointEntity;
    painPointHandler: IPainPointHandler;
    parent: AdminView;
}
interface IColumnViewState {
    isSaving: boolean;
    changed: boolean;
}
class Column extends React.Component<IColumnViewProps, IColumnViewState>{
    static defaultProps = {
        painPointHandler: new PainPointHandler(),
        userId: localStorage.getItem("userId")
    };
    state: IColumnViewState = {
        isSaving: false,
        changed: false
    }
    handleInput = (e: any, propName: string) => {
        const { data } = this.props;
        data[propName] = e.target.value;
        this.setState(
            { changed: true,
              isSaving: false }
        );
    };
    handleNumberInput = (e: any) => {
        const { data } = this.props;
        data.priorityLevel = e;
        this.setState(
            { changed: true,
              isSaving: false }
        );
    };
    handleSelect = (e: any, propName: string, list: SelectOption[]) => {
        const { data } = this.props;
        data[propName] = list[e - 1].name;
        this.setState(
            { changed: true,
              isSaving: false }
        );
    };
    handleSubmit = async () => {
        const { painPointHandler, data} = this.props;
        if (!this.state.changed){
            message.error("No changes were made for this Item! To update an Issue please make changes first!");
            return;
        }
        let result = await painPointHandler.updateById(data.painPointId, data);
        console.log(result);
        this.setState(
            { changed: false,
              isSaving: false }
        );
        message.success("Saved Changes!");
    };

    handleDelete = async () => {
        const { painPointHandler, data, parent} = this.props;
        let num = localStorage.getItem('userId');
        if (num == null){
            message.error("You aren't logged in!");
            return;
        }
        let result = await painPointHandler.deleteById(data.painPointId, parseInt(num));
        console.log(result);
        if (!result.result){
            message.error("Could not delete Issue!");
            return;
        }
        this.setState(
            { changed: false,
              isSaving: false }
        );
        parent.remove(data.painPointId);
        message.success("Deleted Issue!");
    };
    render() {
        let   {handleDelete, handleInput, handleSubmit, handleNumberInput, handleSelect} = this;
        const { data, parent } = this.props;
        let   {changed, isSaving } = this.state;
    return (
        <tr key={data.painPointId}>
                                <td className="thinColumn">{data.createdOn}</td>
                                <td className="megaColumn"><a href={"/home/" + data.painPointId}>{data.title}</a></td>
                                <td className="megaColumn"><TextArea rows={2} key={"summary"} value={data.summary} onChange={(e) => handleInput(e, "painPointSummary")}/></td>
                                <td className="megaColumn"><TextArea rows={2}  key={"annotation"} value={data.annotation} onChange={(e) => handleInput(e, "painPointAnnotation")}/></td>
                                <td className="thinColumn"><Select key={"type"} style={{ width: 100 }} dropdownMatchSelectWidth={false} defaultValue={data.types}  onChange={(e: any) => handleSelect(e, "painPointType", painPointList)}>{parent.renderDropdowns(painPointList)}</Select></td>
                                <td className="thinColumn"><InputNumber key={"severity"} value={data.priorityLevel} min={0} max={5} onChange={(e) => handleNumberInput(e)}/></td>
                                <td className="megaColumn"><Input key={"company"} value={data.companyName} onChange={(e) => handleInput(e, "companyName")}/></td>
                                <td className="thinColumn"><Select key={"industry"} style={{ width: 150 }} dropdownMatchSelectWidth={false} defaultValue={data.industryType} onChange={(e: any) => handleSelect(e, "industryType", industryList)}>{parent.renderDropdowns(industryList)}</Select></td>
                                <td className="thinColumn"><Select key={"status"} style={{ width: 150 }} dropdownMatchSelectWidth={false} defaultValue={data.status}  onChange={(e: any) => handleSelect(e, "submissionStatus", statusList)}>{parent.renderDropdowns(statusList)}</Select></td>
                                <td className="thickColumn">
                                    <Popconfirm title="Save this Issue?" onConfirm={(e) => handleSubmit()} okText="Yes" cancelText="No" placement="left"><Button disabled={isSaving} ><Icon type="save" /></Button></Popconfirm>
                                    <Popconfirm title="Delete this Issue?" onConfirm={handleDelete} okText="Yes" cancelText="No" placement="left"><Button><Icon type="delete" /></Button></Popconfirm>
                                </td>
                            </tr>
      );
    }
}
export default class AdminView extends React.Component<IAdminViewProps, IAdminViewState>{
    static defaultProps = {
        painPointHandler: new PainPointHandler()
    };
    state: IAdminViewState = {
        isFetching: true,
        issues: [],
      };
    renderDropdowns = (list: SelectOption[]) => {
        return list.map((value: any) => (
            <Select.Option key={value.id} value={value.id}>{value.name}</Select.Option>))
    };
    componentDidMount = async () => {
        this.setState({isFetching: true});    
        const {painPointHandler} = this.props;
        let { issues } = this.state;
        if (painPointHandler){
            issues =  (await painPointHandler.getAll()).painPointsList.map(m => new PainPointEntity(m));
        }
        this.setState({isFetching: false, issues})
    }
    remove = (id: number) =>{
        this.setState({
            issues: this.state.issues.filter((el) => id !== el.painPointId)
        })
    }
    render() {
        return (
            <Layout>
                <Content>
                    <h2>Admin Console</h2>
                    <table className="adminTable">
                        <thead className="tableHeader"><tr>
                            <td className="thinColumn">Date Posted</td>
                            <td className="megaColumn">Issue Title</td>
                            <td className="megaColumn">Description</td>
                            <td className="megaColumn">Annotation</td>
                            <td className="thinColumn">Issue Type</td>
                            <td className="thinColumn">Severity</td>
                            <td className="megaColumn">Company Name</td>
                            <td className="thinColumn">Industry Type</td>
                            <td className="thinColumn">Status</td>
                            <td className="thickColumn" colSpan={2}>Edit Issue</td>
                        </tr></thead>
                        <tbody>
                            {this.state.issues.map(i => (<Column painPointHandler={this.props.painPointHandler} data={i} parent={this} />))}
                        </tbody>
                    </table>
                </Content>
            </Layout>
        )
    }
};
