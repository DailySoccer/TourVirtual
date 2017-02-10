//
//  _MDPProductPriceModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPProductPriceModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPProductPriceModelAttributes {
	__unsafe_unretained NSString *coinType;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *price;
	__unsafe_unretained NSString *userType;
} MDPProductPriceModelAttributes;

extern const struct MDPProductPriceModelRelationships {
	__unsafe_unretained NSString *subscriptionConfigurationBasicInfoModelPrice;
	__unsafe_unretained NSString *subscriptionConfigurationPrice;
	__unsafe_unretained NSString *virtualGoodPrice;
} MDPProductPriceModelRelationships;

@class MDPSubscriptionConfigurationBasicInfoModel;
@class MDPSubscriptionConfigurationModel;
@class MDPVirtualGoodModel;

@interface _MDPProductPriceModel : NSManagedObject

@property (nonatomic, strong) NSNumber* coinType;

@property (atomic) uint16_t coinTypeValue;
- (uint16_t)coinTypeValue;
- (void)setCoinTypeValue:(uint16_t)value_;

//- (BOOL)validateCoinType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* price;

//- (BOOL)validatePrice:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* userType;

@property (atomic) int16_t userTypeValue;
- (int16_t)userTypeValue;
- (void)setUserTypeValue:(int16_t)value_;

//- (BOOL)validateUserType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationBasicInfoModel *subscriptionConfigurationBasicInfoModelPrice;

//- (BOOL)validateSubscriptionConfigurationBasicInfoModelPrice:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationModel *subscriptionConfigurationPrice;

//- (BOOL)validateSubscriptionConfigurationPrice:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPVirtualGoodModel *virtualGoodPrice;

//- (BOOL)validateVirtualGoodPrice:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPProductPriceModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCoinType;
- (void)setPrimitiveCoinType:(NSNumber*)value;

- (uint16_t)primitiveCoinTypeValue;
- (void)setPrimitiveCoinTypeValue:(uint16_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDecimalNumber*)primitivePrice;
- (void)setPrimitivePrice:(NSDecimalNumber*)value;

- (NSNumber*)primitiveUserType;
- (void)setPrimitiveUserType:(NSNumber*)value;

- (int16_t)primitiveUserTypeValue;
- (void)setPrimitiveUserTypeValue:(int16_t)value_;

- (MDPSubscriptionConfigurationBasicInfoModel*)primitiveSubscriptionConfigurationBasicInfoModelPrice;
- (void)setPrimitiveSubscriptionConfigurationBasicInfoModelPrice:(MDPSubscriptionConfigurationBasicInfoModel*)value;

- (MDPSubscriptionConfigurationModel*)primitiveSubscriptionConfigurationPrice;
- (void)setPrimitiveSubscriptionConfigurationPrice:(MDPSubscriptionConfigurationModel*)value;

- (MDPVirtualGoodModel*)primitiveVirtualGoodPrice;
- (void)setPrimitiveVirtualGoodPrice:(MDPVirtualGoodModel*)value;

@end
