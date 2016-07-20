//
//  _MDPStateModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPStateModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPStateModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *countryCode;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *stateCode;
} MDPStateModelAttributes;

@interface _MDPStateModel : NSManagedObject

@property (nonatomic, strong) NSData* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* countryCode;

//- (BOOL)validateCountryCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* stateCode;

//- (BOOL)validateStateCode:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPStateModel (CoreDataGeneratedPrimitiveAccessors)

- (NSData*)primitiveAlias;
- (void)setPrimitiveAlias:(NSData*)value;

- (NSString*)primitiveCountryCode;
- (void)setPrimitiveCountryCode:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitiveStateCode;
- (void)setPrimitiveStateCode:(NSString*)value;

@end
