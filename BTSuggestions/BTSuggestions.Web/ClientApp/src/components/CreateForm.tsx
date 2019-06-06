import React from 'react';
import { Layout, Form as AntForm, Select, Input, Button, Slider, Icon } from 'antd';
import * as yup from 'yup';
import { painPointList } from '../types/dropdownValues/painPointTypes';
import { industryList } from '../types/dropdownValues/industryTypes';
import { withFormik, InjectedFormikProps, Form } from 'formik';
import CreateFormEntity from '../entity/CreateFormEntity';
import { SelectOption } from '../types/dropdownValues/SelectOption';
import '../styles/CreateForm.css';
import TextArea from 'antd/lib/input/TextArea';
import { IPainPointHandler } from '../utilities/painPointHandler';
import PainPointEntity from '../entity/PainPointEntity';

const { Content } = Layout;
const FormItem = AntForm.Item;

interface ICreateFormProps {
    
    painPointHandler?: IPainPointHandler;
    handleSave: (entity: PainPointEntity) => Promise<void>;
    data: CreateFormEntity;
}

interface ICreateFormState {
        title: string;
        summary: string;
        annotation?: string;
        status: string;
        userId?: number;
        priorityLevel: number;
        companyName?: string;
        companyContact?: string;
        companyLocation?: string;
        industryType?: string;
        createdOn: Date;
        types: string[];
}
interface INewCreateForm{
    painPointType: string[],
    painPointTitle: string,
    painPointSummary: string,
    painPointAnnotation?: string,
    painPointSeverity: number,

    companyName?: string,
    companyContact?: string,
    companyLocation?: string,
    industryType?: string
}
const yupValidation = yup.object().shape<INewCreateForm>({
    painPointType: yup.array<string>(),
    painPointTitle: yup.string().min(2).max(150).required().label('Issue Title'),
    painPointSummary: yup.string().min(2).max(1500).required().label('Issue Summmary'),
    painPointSeverity: yup.number().min(0).max(10).required().label('Issue Severity'),
    painPointAnnotation: yup.string().min(1).max(1500).label('Issue Annotation'),

    companyName: yup.string().label('Company Name'),
    companyContact: yup.string().label('Company Contact'),
    companyLocation: yup.string().label('Company Location'),
    industryType: yup.string().label('Industry Type')
})

class CreateForm extends React.Component<InjectedFormikProps<ICreateFormProps, INewCreateForm>>{
    static defaultProps = {
    };
    
    state = {
        inputValue: 0
    };

    slideChange = (value: any) => {
        this.setState({
            inputValue: value
        });
    };
    handleSave = async (entity: PainPointEntity): Promise<void> => {
          await this.props.painPointHandler!.createPainPoint(entity)
      }
    getValidationStatus = (error: any) => {
        return !!error ? 'error' : 'success';
    };

    renderDropdowns = (list: SelectOption[]) => {
        return list.map((value: any) => (
            <Select.Option key={value.id} value={value.id}>{value.name}</Select.Option>))
    };

    sliderFormatter = (value: number) => {
        return `${value}`;
    }

    render() {
        const { values, handleSubmit, errors, handleChange, setFieldValue } = this.props;
        const { inputValue } = this.state;
        return (
            <Layout>
                <Content>
                    <Form onSubmitCapture={handleSubmit} className="create-form">
                        <h1>Create New Issue</h1>
                        <div className="required-components">
                            <FormItem className="input" label="Issue Title" required validateStatus={this.getValidationStatus(errors.painPointTitle)}>
                                <Input id="painPointTitle" placeholder="Title" value={values.painPointTitle} onChange={handleChange} />
                            </FormItem>
                            <FormItem className="input" label="Issue Summary" required validateStatus={this.getValidationStatus(errors.painPointSummary)}>
                                <TextArea id="painPointSummary" placeholder="Description of Problem" value={values.painPointSummary} onChange={handleChange} rows={2} />
                            </FormItem>
                            <FormItem className="input" label="Issue Annotation" validateStatus={this.getValidationStatus(errors.painPointAnnotation)}>
                                <TextArea id="painPointAnnotation" placeholder="Personal Notes about Problem" value={values.painPointAnnotation} onChange={handleChange} rows={2} />
                            </FormItem>
                            <FormItem className="input" label="Issue Type" required validateStatus={this.getValidationStatus(errors.painPointType)}>
                                <Select mode="multiple" id="painPointType" onChange={(x:any) => setFieldValue("painPointType", x)} value={values.painPointType}>{this.renderDropdowns(painPointList)}</Select>
                            </FormItem>
                            <FormItem label="Issue Severity" required validateStatus={this.getValidationStatus(errors.painPointSeverity)}>
                                <div className="wrapper">
                                    <Icon type="fire" theme="twoTone" twoToneColor="#ff3300" />
                                    <Slider tipFormatter={this.sliderFormatter} className="slider" id="painPointSeveritySlide" min={0} max={100} onChange={this.slideChange} value={typeof inputValue === 'number' ? inputValue : 0} />
                                    <Icon type="fire" theme="twoTone" twoToneColor="#ff3300" />
                                    <Icon type="fire" theme="twoTone" twoToneColor="#ff3300" />
                                    <Icon type="fire" theme="twoTone" twoToneColor="#ff3300" />
                                </div>
                            </FormItem>
                        </div>
                        <div className="customer-components">
                            <FormItem className="input" label="Company Contact" validateStatus={this.getValidationStatus(errors.companyContact)}>
                                <Input id="companyContact" placeholder="Company Contact Name" onChange={handleChange} value={values.companyContact} />
                            </FormItem>
                            <FormItem className="input" label="Company Name" validateStatus={this.getValidationStatus(errors.companyName)}>
                                <Input id="companyName" placeholder="Company Name" onChange={handleChange} value={values.companyName} />
                            </FormItem>
                            <FormItem className="input" label="Company Location" validateStatus={this.getValidationStatus(errors.companyLocation)}>
                                <Input id="companyLocation" placeholder="Company Location" onChange={handleChange} value={values.companyLocation} />
                            </FormItem>
                            <FormItem className="input" label="Industry Type" validateStatus={this.getValidationStatus(errors.industryType)}>
                                <Select id="industryType" onChange={(x:any) => setFieldValue("industryType", x)} value={values.industryType}>{this.renderDropdowns(industryList)}</Select>
                            </FormItem>
                            <FormItem>
                                <Button className="button" id="submit" htmlType="submit">Submit Problem</Button>
                            </FormItem>
                        </div>
                    </Form>
                    <div>
              {JSON.stringify(values)}
            </div>
                </Content>
            </Layout>
        )
    }
};

export default withFormik<ICreateFormProps, INewCreateForm>({
    mapPropsToValues: props => ({
        painPointType: [""],
        painPointTitle: "",
        painPointSummary: "",
        painPointAnnotation: "",
        painPointSeverity: 0,
        companyName: "",
        companyContact: "",
        companyLocation: "",
        industryType: "",
        
    }),
    validationSchema: yupValidation,
    handleSubmit: async (values, { setSubmitting, props }) =>  {
        console.log(values);
        await props.handleSave(new PainPointEntity(values));
        alert("You have submitted an issue");
        setSubmitting(false);
    },
    displayName: 'Create Issue Form'
})(CreateForm);
