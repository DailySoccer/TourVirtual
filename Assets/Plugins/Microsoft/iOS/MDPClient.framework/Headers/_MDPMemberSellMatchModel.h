//
//  _MDPMemberSellMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMemberSellMatchModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMemberSellMatchModelAttributes {
	__unsafe_unretained NSString *available;
	__unsafe_unretained NSString *canBeSold;
	__unsafe_unretained NSString *idMatchAvet;
	__unsafe_unretained NSString *lastSellDate;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *origin;
	__unsafe_unretained NSString *price;
	__unsafe_unretained NSString *status;
} MDPMemberSellMatchModelAttributes;

extern const struct MDPMemberSellMatchModelRelationships {
	__unsafe_unretained NSString *match;
} MDPMemberSellMatchModelRelationships;

@class MDPMatchModel;

@interface _MDPMemberSellMatchModel : NSManagedObject

@property (nonatomic, strong) NSNumber* available;

@property (atomic) BOOL availableValue;
- (BOOL)availableValue;
- (void)setAvailableValue:(BOOL)value_;

//- (BOOL)validateAvailable:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* canBeSold;

@property (atomic) BOOL canBeSoldValue;
- (BOOL)canBeSoldValue;
- (void)setCanBeSoldValue:(BOOL)value_;

//- (BOOL)validateCanBeSold:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* idMatchAvet;

@property (atomic) int64_t idMatchAvetValue;
- (int64_t)idMatchAvetValue;
- (void)setIdMatchAvetValue:(int64_t)value_;

//- (BOOL)validateIdMatchAvet:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastSellDate;

//- (BOOL)validateLastSellDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* origin;

//- (BOOL)validateOrigin:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* price;

//- (BOOL)validatePrice:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* status;

@property (atomic) uint16_t statusValue;
- (uint16_t)statusValue;
- (void)setStatusValue:(uint16_t)value_;

//- (BOOL)validateStatus:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPMatchModel *match;

//- (BOOL)validateMatch:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPMemberSellMatchModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAvailable;
- (void)setPrimitiveAvailable:(NSNumber*)value;

- (BOOL)primitiveAvailableValue;
- (void)setPrimitiveAvailableValue:(BOOL)value_;

- (NSNumber*)primitiveCanBeSold;
- (void)setPrimitiveCanBeSold:(NSNumber*)value;

- (BOOL)primitiveCanBeSoldValue;
- (void)setPrimitiveCanBeSoldValue:(BOOL)value_;

- (NSNumber*)primitiveIdMatchAvet;
- (void)setPrimitiveIdMatchAvet:(NSNumber*)value;

- (int64_t)primitiveIdMatchAvetValue;
- (void)setPrimitiveIdMatchAvetValue:(int64_t)value_;

- (NSDate*)primitiveLastSellDate;
- (void)setPrimitiveLastSellDate:(NSDate*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveOrigin;
- (void)setPrimitiveOrigin:(NSString*)value;

- (NSDecimalNumber*)primitivePrice;
- (void)setPrimitivePrice:(NSDecimalNumber*)value;

- (NSNumber*)primitiveStatus;
- (void)setPrimitiveStatus:(NSNumber*)value;

- (uint16_t)primitiveStatusValue;
- (void)setPrimitiveStatusValue:(uint16_t)value_;

- (MDPMatchModel*)primitiveMatch;
- (void)setPrimitiveMatch:(MDPMatchModel*)value;

@end
