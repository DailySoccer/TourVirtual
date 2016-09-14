//
//  _MDPPaidFanLinkedStatusModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPaidFanLinkedStatusModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPaidFanLinkedStatusModelAttributes {
	__unsafe_unretained NSString *fanEmail;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *paidFanEmail;
	__unsafe_unretained NSString *status;
	__unsafe_unretained NSString *unsubscribedStatus;
} MDPPaidFanLinkedStatusModelAttributes;

@interface _MDPPaidFanLinkedStatusModel : NSManagedObject

@property (nonatomic, strong) NSString* fanEmail;

//- (BOOL)validateFanEmail:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* paidFanEmail;

//- (BOOL)validatePaidFanEmail:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* status;

@property (atomic) int16_t statusValue;
- (int16_t)statusValue;
- (void)setStatusValue:(int16_t)value_;

//- (BOOL)validateStatus:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* unsubscribedStatus;

@property (atomic) int16_t unsubscribedStatusValue;
- (int16_t)unsubscribedStatusValue;
- (void)setUnsubscribedStatusValue:(int16_t)value_;

//- (BOOL)validateUnsubscribedStatus:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPaidFanLinkedStatusModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveFanEmail;
- (void)setPrimitiveFanEmail:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitivePaidFanEmail;
- (void)setPrimitivePaidFanEmail:(NSString*)value;

- (NSNumber*)primitiveStatus;
- (void)setPrimitiveStatus:(NSNumber*)value;

- (int16_t)primitiveStatusValue;
- (void)setPrimitiveStatusValue:(int16_t)value_;

- (NSNumber*)primitiveUnsubscribedStatus;
- (void)setPrimitiveUnsubscribedStatus:(NSNumber*)value;

- (int16_t)primitiveUnsubscribedStatusValue;
- (void)setPrimitiveUnsubscribedStatusValue:(int16_t)value_;

@end
