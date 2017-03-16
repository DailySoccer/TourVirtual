//
//  _MDPVideoAdInformationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPVideoAdInformationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPVideoAdInformationModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *midroll;
	__unsafe_unretained NSString *postroll;
	__unsafe_unretained NSString *preroll;
} MDPVideoAdInformationModelAttributes;

@interface _MDPVideoAdInformationModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* midroll;

//- (BOOL)validateMidroll:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* postroll;

//- (BOOL)validatePostroll:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* preroll;

//- (BOOL)validatePreroll:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPVideoAdInformationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMidroll;
- (void)setPrimitiveMidroll:(NSString*)value;

- (NSString*)primitivePostroll;
- (void)setPrimitivePostroll:(NSString*)value;

- (NSString*)primitivePreroll;
- (void)setPrimitivePreroll:(NSString*)value;

@end
