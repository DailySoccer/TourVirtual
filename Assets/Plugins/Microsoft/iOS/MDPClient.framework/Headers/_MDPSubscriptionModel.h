//
//  _MDPSubscriptionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPSubscriptionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPSubscriptionModelAttributes {
	__unsafe_unretained NSString *disableDate;
	__unsafe_unretained NSString *disabledReason;
	__unsafe_unretained NSString *enabled;
	__unsafe_unretained NSString *expirationDate;
	__unsafe_unretained NSString *idSubscription;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *subscriptionDate;
	__unsafe_unretained NSString *type;
} MDPSubscriptionModelAttributes;

@interface _MDPSubscriptionModel : NSManagedObject

@property (nonatomic, strong) NSDate* disableDate;

//- (BOOL)validateDisableDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* disabledReason;

@property (atomic) uint16_t disabledReasonValue;
- (uint16_t)disabledReasonValue;
- (void)setDisabledReasonValue:(uint16_t)value_;

//- (BOOL)validateDisabledReason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* enabled;

@property (atomic) BOOL enabledValue;
- (BOOL)enabledValue;
- (void)setEnabledValue:(BOOL)value_;

//- (BOOL)validateEnabled:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* expirationDate;

//- (BOOL)validateExpirationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSubscription;

//- (BOOL)validateIdSubscription:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* subscriptionDate;

//- (BOOL)validateSubscriptionDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* type;

//- (BOOL)validateType:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPSubscriptionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveDisableDate;
- (void)setPrimitiveDisableDate:(NSDate*)value;

- (NSNumber*)primitiveDisabledReason;
- (void)setPrimitiveDisabledReason:(NSNumber*)value;

- (uint16_t)primitiveDisabledReasonValue;
- (void)setPrimitiveDisabledReasonValue:(uint16_t)value_;

- (NSNumber*)primitiveEnabled;
- (void)setPrimitiveEnabled:(NSNumber*)value;

- (BOOL)primitiveEnabledValue;
- (void)setPrimitiveEnabledValue:(BOOL)value_;

- (NSDate*)primitiveExpirationDate;
- (void)setPrimitiveExpirationDate:(NSDate*)value;

- (NSString*)primitiveIdSubscription;
- (void)setPrimitiveIdSubscription:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDate*)primitiveSubscriptionDate;
- (void)setPrimitiveSubscriptionDate:(NSDate*)value;

- (NSString*)primitiveType;
- (void)setPrimitiveType:(NSString*)value;

@end
