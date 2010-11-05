/*!
 * Ext JS Library 3.3.0
 * Copyright(c) 2006-2010 Ext JS, Inc.
 * licensing@extjs.com
 * http://www.extjs.com/license
 */

    Ext.QuickTips.init();
    
    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';
    
    // combine all that into one huge form
    var fp = new Ext.FormPanel({
        title: '�����ϼ���',
        frame: true,
        region:'center',
        labelWidth: 110,
        width: 600,
//        renderTo:'form-ct',
        bodyStyle: 'padding:0 10px 0;',
        items: [{
            xtype: 'radiogroup',
            fieldLabel: '�Ĵ� ����',
            itemCls: 'x-check-group-alt',
            columns: 1,
            items: [
                {boxLabel: '�����Ĵ�', name: 'rb-col', inputValue: 1},
                {boxLabel: '���۵���', name: 'rb-col', inputValue: 2},
                {boxLabel: '�谡��', name: 'rb-col', inputValue: 3},
                {boxLabel: '�밡', name: 'rb-col', inputValue: 3},
                {boxLabel: '��', name: 'rb-col', inputValue: 3},
                {boxLabel: '�߽Ĵ�', name: 'rb-col', inputValue: 3}
            ]
        }],
        buttons: [{
            text: 'Save',
            handler: function(){
               if(fp.getForm().isValid()){
                    Ext.Msg.alert('Submitted Values', 'The following will be sent to the server: <br />'+ 
                        fp.getForm().getValues(true).replace(/&/g,', '));
                }
            }
        },{
            text: 'Reset',
            handler: function(){
                fp.getForm().reset();
            }
        }]
    });
