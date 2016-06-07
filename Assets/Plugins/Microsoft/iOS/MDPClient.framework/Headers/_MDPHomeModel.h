//
//  _MDPHomeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPHomeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPHomeModelAttributes {
	__unsafe_unretained NSString *aspectRatio;
	__unsafe_unretained NSString *column;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *idHome;
	__unsafe_unretained NSString *idService;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *onlyMatchDay;
	__unsafe_unretained NSString *order;
	__unsafe_unretained NSString *parameters;
	__unsafe_unretained NSString *sportType;
	__unsafe_unretained NSString *visible;
} MDPHomeModelAttributes;

@interface _MDPHomeModel : NSManagedObject

@property (nonatomic, strong) NSDecimalNumber* aspectRatio;

//- (BOOL)validateAspectRatio:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* column;

@property (atomic) uint64_t columnValue;
- (uint64_t)columnValue;
- (void)setColumnValue:(uint64_t)value_;

//- (BOOL)validateColumn:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idHome;

//- (BOOL)validateIdHome:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idService;

//- (BOOL)validateIdService:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* onlyMatchDay;

@property (atomic) BOOL onlyMatchDayValue;
- (BOOL)onlyMatchDayValue;
- (void)setOnlyMatchDayValue:(BOOL)value_;

//- (BOOL)validateOnlyMatchDay:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* order;

@property (atomic) uint64_t orderValue;
- (uint64_t)orderValue;
- (void)setOrderValue:(uint64_t)value_;

//- (BOOL)validateOrder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* parameters;

//- (BOOL)validateParameters:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sportType;

@property (atomic) uint16_t sportTypeValue;
- (uint16_t)sportTypeValue;
- (void)setSportTypeValue:(uint16_t)value_;

//- (BOOL)validateSportType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* visible;

@property (atomic) BOOL visibleValue;
- (BOOL)visibleValue;
- (void)setVisibleValue:(BOOL)value_;

//- (BOOL)validateVisible:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPHomeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDecimalNumber*)primitiveAspectRatio;
- (void)setPrimitiveAspectRatio:(NSDecimalNumber*)value;

- (NSNumber*)primitiveColumn;
- (void)setPrimitiveColumn:(NSNumber*)value;

- (uint64_t)primitiveColumnValue;
- (void)setPrimitiveColumnValue:(uint64_t)value_;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSString*)primitiveIdHome;
- (void)setPrimitiveIdHome:(NSString*)value;

- (NSString*)primitiveIdService;
- (void)setPrimitiveIdService:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveOnlyMatchDay;
- (void)setPrimitiveOnlyMatchDay:(NSNumber*)value;

- (BOOL)primitiveOnlyMatchDayValue;
- (void)setPrimitiveOnlyMatchDayValue:(BOOL)value_;

- (NSNumber*)primitiveOrder;
- (void)setPrimitiveOrder:(NSNumber*)value;

- (uint64_t)primitiveOrderValue;
- (void)setPrimitiveOrderValue:(uint64_t)value_;

- (NSString*)primitiveParameters;
- (void)setPrimitiveParameters:(NSString*)value;

- (NSNumber*)primitiveSportType;
- (void)setPrimitiveSportType:(NSNumber*)value;

- (uint16_t)primitiveSportTypeValue;
- (void)setPrimitiveSportTypeValue:(uint16_t)value_;

- (NSNumber*)primitiveVisible;
- (void)setPrimitiveVisible:(NSNumber*)value;

- (BOOL)primitiveVisibleValue;
- (void)setPrimitiveVisibleValue:(BOOL)value_;

@end
