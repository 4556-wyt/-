
public abstract class 基础状态
{
    protected 敌人 当前敌人;

    
    public abstract void 进入(敌人 x敌人);

   
    public abstract void 逻辑判断();

    public abstract void 物理判断();

    public abstract void 退出();
}
